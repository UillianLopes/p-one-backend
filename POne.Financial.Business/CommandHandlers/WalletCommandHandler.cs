using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Financial.Domain.Commands.Inputs.Wallets;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class WalletCommandHandler :
        ICommandHandler<CreateWalletCommand>,
        ICommandHandler<UpdateWalletCommand>,
        ICommandHandler<DeleteWalletCommand>,
        ICommandHandler<DeleteWalletsCommand>,
        ICommandHandler<DepositCommand>,
        ICommandHandler<WithdrawCommand>,
        ICommandHandler<TransferCommand>
    {
        private readonly IWalletRepository _walletRespository;
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IBankRepository _bankRepsitory;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IEntryRepository _entryRepository;

        public WalletCommandHandler(IWalletRepository walletRespository, IAuthenticatedUser authenticatedUser, IBankRepository bankRepsitory, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, IEntryRepository entryRepository)
        {
            _walletRespository = walletRespository;
            _authenticatedUser = authenticatedUser;
            _bankRepsitory = bankRepsitory;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _entryRepository = entryRepository;
        }

        public async Task<ICommandOuput> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            Bank bank = null;

            if (request.BankId is Guid bankId)
                bank = await _bankRepsitory.FindByIdAync(bankId, cancellationToken);

            var balance = new Wallet(
                _authenticatedUser.Id,
                _authenticatedUser.AccountId,
                request.Value,
                request.Name,
                bank,
                request.Number,
                request.Agency,
                request.Type,
                request.Color,
                request.Currency
            );

            await _walletRespository.CreateAync(balance, cancellationToken);

            return CommandOutput.Created($"/category/{balance.Id}", new
            {
                balance.Id,
                request.Value,
                request.Name,
                request.Number,
                request.Agency,
                Bank = bank != null ? new { bank.Id, bank.Name, bank.Code } : null

            }, "@PONE.MESSAGES.WALLET_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            if (await _walletRespository.FindByIdAync(request.Id, cancellationToken) is not Wallet wallet)
                return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");
            Bank bank = null;

            if (request.BankId is Guid bankId)
                bank = await _bankRepsitory.FindByIdAync(bankId, cancellationToken);

            wallet.Update(
                request.Name,
                bank,
                request.Number,
                request.Agency,
                request.Color,
                request.Currency
            );

            return CommandOutput.Ok(new
            {
                wallet.Id,
                wallet.Value,
                wallet.Name,
                wallet.Number,
                wallet.Agency,
                wallet.Color,
                Bank = bank != null ? new { bank.Id, bank.Name, bank.Code } : null
            }, "@PONE.MESSAGES.WALLET_UPDATED");
        }

        public async Task<ICommandOuput> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            if (await _walletRespository.FindByIdAync(request.Id, cancellationToken) is not Wallet wallet)
                return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");

            _walletRespository.Delete(wallet);

            return CommandOutput.Ok("@PONE.MESSAGES.WALLET_DELETED");
        }

        public async Task<ICommandOuput> Handle(DeleteWalletsCommand request, CancellationToken cancellationToken)
        {
            if (await _walletRespository.FindByIdsAync(request.Ids, cancellationToken) is not List<Wallet> wallets || wallets.Count == 0)
                return CommandOutput.NotFound("@PONE.MESSAGES.WALLETS_NOT_FOUND");

            _walletRespository.DeleteRange(wallets.ToArray());

            return CommandOutput.Ok("@PONE.MESSAGES.WALLETS_DELETED");
        }

        public async Task<ICommandOuput> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            if (await _walletRespository.FindByIdAync(request.WalletId, cancellationToken) is not Wallet wallet)
                return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");

            if (await _categoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("PONE.MESSAGES.CATEGORY_NOT_FOUND");

            SubCategory subCategory = null;

            if (request.SubCategoryId is Guid subCategoryId)
                subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

            var entry = Entry.Standard(
                _authenticatedUser.AccountId,
                _authenticatedUser.Id,
                request.DueDate,
                request.Deposit,
                EntryOperation.Credit,
                null,
                wallet.Currency,
                request.Description,
                request.Title,
                category,
                subCategory,
                wallet,
                null
            );

            await _entryRepository.CreateAync(entry, cancellationToken);

            entry.Pay(wallet, request.Deposit);

            return CommandOutput.Ok("@PONE.MESSAGES.DEPOSIT_DONE");
        }

        public async Task<ICommandOuput> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            if (await _walletRespository.FindByIdAync(request.WalletId, cancellationToken) is not Wallet wallet)
                return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");

            if (await _categoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

            SubCategory subCategory = null;

            if (request.SubCategoryId is Guid subCategoryId)
                subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

            var entry = Entry.Standard(
                _authenticatedUser.AccountId,
                _authenticatedUser.Id,
                request.DueDate,
                request.Withdraw,
                EntryOperation.Debit,
                null,
                wallet.Currency,
                request.Description,
                request.Title,
                category,
                subCategory,
                wallet,
                null
            );

            await _entryRepository.CreateAync(entry, cancellationToken);

            entry.Pay(wallet, request.Withdraw);

            return CommandOutput.Ok("@PONE.MESSAGES.WITHDRAW_DONE");
        }

        public async Task<ICommandOuput> Handle(TransferCommand request, CancellationToken cancellationToken)
        {

            if (request.Origin is TransferSubject origin)
            {
                if (await _walletRespository.FindByIdAync(origin.WalletId, cancellationToken) is not Wallet wallet)
                    return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");

                if (await _categoryRepository.FindByIdAync(origin.CategoryId, cancellationToken) is not Category category)
                    return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

                SubCategory subCategory = null;
                if (origin.SubCategoryId is Guid subCategoryId)
                    subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

                var entry = Entry.Standard(
                    _authenticatedUser.AccountId,
                    _authenticatedUser.Id,
                    request.DueDate,
                    request.Value,
                    EntryOperation.Debit,
                    null,
                    wallet.Currency,
                    request.Description,
                    request.Title,
                    category,
                    subCategory,
                    wallet,
                    null
                );

                await _entryRepository.CreateAync(entry, cancellationToken);

                entry.Pay(wallet, request.Value);
            }

            if (request.Destination is TransferSubject destination)
            {
                if (await _walletRespository.FindByIdAync(destination.WalletId, cancellationToken) is not Wallet wallet)
                    return CommandOutput.NotFound("@PONE.MESSAGES.WALLET_NOT_FOUND");

                if (await _categoryRepository.FindByIdAync(destination.CategoryId, cancellationToken) is not Category category)
                    return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

                SubCategory subCategory = null;
                if (destination.SubCategoryId is Guid subCategoryId)
                    subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

                var entry = Entry.Standard(
                    _authenticatedUser.AccountId,
                    _authenticatedUser.Id,
                    request.DueDate,
                    request.Value,
                    EntryOperation.Credit,
                    null,
                    wallet.Currency,
                    request.Description,
                    request.Title,
                    category,
                    subCategory,
                    wallet,
                    null
                );

                await _entryRepository.CreateAync(entry, cancellationToken);

                entry.Pay(wallet, request.Value);
            }

            return CommandOutput.Ok("@PONE.MESSAGES.TRANSFER_COMPLETED");
        }
    }
}
