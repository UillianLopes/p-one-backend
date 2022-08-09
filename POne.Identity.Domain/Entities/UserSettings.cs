using POne.Core.ValueObjects;
using POne.Identity.Domain.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Entities
{
    public class UserSettings : ValueObject
    {
        public UserSettings() : base() { }

        public string Value { get; private set; }

        public async Task UpdateAsync(GeneralSettings userSettings, CancellationToken cancellationToken)
        {
            if (userSettings == null)
            {
                Value = string.Empty;
                return;
            }

            using var stream = new MemoryStream();

            await JsonSerializer.SerializeAsync(stream, userSettings, cancellationToken: cancellationToken);

            stream.Position = 0;

            using var streamReader = new StreamReader(stream);


            if (await streamReader.ReadToEndAsync() is string settings && !string.IsNullOrEmpty(settings))
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(settings));
            else
                Value = null;
        }

        public async Task<GeneralSettings> ReadAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Value))
                return null;

            using var stream = new MemoryStream(Convert.FromBase64String(Value));

            var generalSettings = await JsonSerializer
                .DeserializeAsync<GeneralSettings>(stream, cancellationToken: cancellationToken);

            return generalSettings;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;

        }
    }
}
