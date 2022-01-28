using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class ObjectionMapper
    {
        public static Objection ObjectionDTOToObjection(ObjectionDTO objection) {
            return new Objection(objection.TextObjection, objection.PharmacyName);
        }

        public static ObjectionDTO ObjectionToObjectionDTO(Objection objection) {
            return new ObjectionDTO (objection.TextObjection, objection.PharmacyName);
        }

        public static List<ObjectionResponseDTO> ObjectionResponsesToObjectionResponseDTO(List<Objection> objections, List<Response> responses) {
            List<ObjectionResponseDTO> objectionResponseDTOs = new List<ObjectionResponseDTO>();
            foreach (Objection o in objections) {
                ObjectionResponseDTO objectionResponse = new ObjectionResponseDTO(o.TextObjection, o.PharmacyName, "no response");
                foreach (Response r in responses) {
                    if (r.ObjectionId.Equals(o.Id.ToString())) {
                        objectionResponse.TextResponse = r.TextResponse;
                        break;
                    }
                }
                objectionResponseDTOs.Add(objectionResponse);
            }
            return objectionResponseDTOs;
        }

    }
}
