using POne.Core.ValueObjects;
using POne.Identity.Domain.Settings;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Entities
{
    public class UserSettings : ValueObject
    {
        protected UserSettings() : base() { }

        public string Configuration { get; private set; }

        public async Task UpdateAsync(GeneralSettings userSettings, CancellationToken cancellationToken)
        {
            if (userSettings == null)
            {
                Configuration = string.Empty;
                return;
            }

            using var stream = new MemoryStream();

            await JsonSerializer.SerializeAsync(stream, userSettings, cancellationToken: cancellationToken);

            using var streamReader = new StreamReader(stream);

            Configuration = await streamReader.ReadToEndAsync();
        }

        public async Task<GeneralSettings> ReadAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Configuration))
                return null;

            using var stream = new MemoryStream();

            using var sw = new StreamWriter(stream);

            sw.Write(Configuration);

            return await JsonSerializer.DeserializeAsync<GeneralSettings>(stream, cancellationToken: cancellationToken);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Configuration;

        }
    }
}
