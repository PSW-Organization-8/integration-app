using Grpc.Core;
using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationAPI.Protos;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection
{
    public class PharmacyGrpcConnection : IPharmacyGrpcConnection
    {
        public List<PharmacyWithInventoryDTO> GetPharmaciesWithAvailableMedicine(Pharmacy pharmacy, string name, string quantity)
        {
            MedicationGrpcService.MedicationGrpcServiceClient client = GetClient(pharmacy);
            CheckMedicationAvailabilityResponseProto response = client.CheckMedicationQuantity(new CheckMedicationAvailabilityProto() { Name = name, Quantity = int.Parse(quantity), ApiKey=pharmacy.ApiKey });
            return MedicationMapper.PharmacyDtoToPharmacy(response);
        }

        public bool OrderMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto)
        {
            MedicationGrpcService.MedicationGrpcServiceClient client = GetClient(pharmacy);
            return client.OrderMedication(new OrderProto { PharmacyID = orderMedicationDto.PharmacyId, MedicationID = orderMedicationDto.MedicationId, Quantity = orderMedicationDto.Quantity, ApiKey = pharmacy.ApiKey }).Response;
        }

        public bool ReturnMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto)
        {
            MedicationGrpcService.MedicationGrpcServiceClient client = GetClient(pharmacy);
            return client.ReturnMedication(new OrderProto { PharmacyID = orderMedicationDto.PharmacyId, MedicationID = orderMedicationDto.MedicationId, Quantity = orderMedicationDto.Quantity, ApiKey = pharmacy.ApiKey }).Response;

        }

        private MedicationGrpcService.MedicationGrpcServiceClient GetClient(Pharmacy pharmacy)
        {
            string pharmacyUrlPort = pharmacy.Url + ":" + pharmacy.Port;
            Channel channel = new Channel(pharmacyUrlPort, ChannelCredentials.Insecure);
            return new MedicationGrpcService.MedicationGrpcServiceClient(channel);
        }
    }
}
