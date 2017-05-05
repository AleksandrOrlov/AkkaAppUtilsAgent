using UtilsAgent.Core.Commands;
using UtilsAgent.Core.Dto;
using UtilsAgent.Core.Interfaces;

namespace UtilsAgent.ExternalCommands
{
    public class ExternalCloneCompany : BaseExternalCommand
    {
        public string CompanyId { get; }

        public int CopyCount { get; }

        public ExternalCloneCompany(ExternalRequest request)
            : base(request)
        {
            CompanyId = GetValue<string>("companyId");
            CopyCount = GetValue<int>("copyCount");
        }

        public ExternalCloneCompany(string companyId, int copyCount)
        {
            CopyCount = copyCount;
            CompanyId = companyId;
        }

        public override IValidationCommandResult Validate()
        {
            var result = new ValidationCommandResult();
            if (string.IsNullOrEmpty(CompanyId))
                result.AddError(ValidationError.NullProperty(nameof(CompanyId)));

            if (CopyCount <= 0)
                result.AddError(ValidationError.NullProperty(nameof(CopyCount)));

            return result;
        }
    }
}
