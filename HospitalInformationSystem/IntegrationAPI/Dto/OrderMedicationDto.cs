namespace IntegrationAPI.Dto
{
    public class OrderMedicationDto
    {
        public string PharmacyName { get; set; }
        public int PharmacyId { get; set; }
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public int Quantity { get; set; }

    }
}
