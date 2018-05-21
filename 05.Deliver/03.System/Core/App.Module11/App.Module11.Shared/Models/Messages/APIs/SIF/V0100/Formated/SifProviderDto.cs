namespace App.Module11.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifProviderDto
    {
        public string RefId { get; set; }



        public int LocalId { get; set; }

        public string Authority { get; set; }

        public SifOrganisationDto Organisation { get; set; }

        public SifSchoolServiceDto SchoolService { get; set; }

    }
}
