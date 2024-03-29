﻿namespace POne.Notifier.Domain.Contracts.Facades
{
    public interface INotificationsHubFacade
    {
        Task NotificateAsync(string userId, object notification, CancellationToken cancellationToken);

        Task NotificateAsync(object notification, CancellationToken cancellationToken);
    }
}
