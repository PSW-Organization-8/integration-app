using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic.CompilerServices;

namespace IntegrationClassLib.Parthership.Service
{
    public class EmailService
    {
        private readonly NetworkCredential emailCredentials;
        private readonly SmtpClient smtp;
        private readonly ITenderingRepository tenderingRepository;
        private readonly IPharmacyOfferRepository pharmacyOfferRepository;
        private readonly IPharmacyRepository pharmacyRepository;

        public EmailService(ITenderingRepository tenderingRepository, IPharmacyOfferRepository pharmacyOfferRepository,
            IPharmacyRepository pharmacyRepository)
        {
            this.tenderingRepository = tenderingRepository;
            this.pharmacyOfferRepository = pharmacyOfferRepository;
            this.pharmacyRepository = pharmacyRepository;

            emailCredentials = new NetworkCredential(Environment.GetEnvironmentVariable("EMAIL_USERNAME") ?? "psworganisation8@outlook.com", Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? "pswFtnOrganisation8");
            smtp = new SmtpClient();
            smtp.Port = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT") ?? "587");
            smtp.Host = Environment.GetEnvironmentVariable("EMAIL_HOST") ?? "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = this.emailCredentials;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void SendTenderEmail(long tenderId)
        {
            try
            {
                Tender tender = tenderingRepository.Get(tenderId);

                foreach (var pharmacyOffer in pharmacyOfferRepository.GetAllWithComponents()
                             .Where(pharmacyOffer => pharmacyOffer.TenderId == tenderId).ToList())
                {
                    SendMailToOnePharmacy(pharmacyOffer, tender);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SendMailToOnePharmacy(PharmacyOffer pharmacyOffer, Tender tender)
        {
            Pharmacy.Model.Pharmacy pharmacy = pharmacyRepository.GetPharmacyByName(pharmacyOffer.PharmacyName);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.emailCredentials.UserName);
            message.To.Add(new MailAddress(pharmacy.EmailAddress));
            message.Subject = "Tender: \"" + tender.Name + "\"";
            message.IsBodyHtml = true;
            message.Body = tender.WinnerOfferId == pharmacyOffer.Id
                ? GetBodyMessageForWinnerOffer(pharmacy, tender, pharmacyOffer)
                : GetBodyMessageForNonWinnerOffer(pharmacy, tender, pharmacyOffer);

            smtp.Send(message);
        }

        private string GetBodyMessageForNonWinnerOffer(Pharmacy.Model.Pharmacy pharmacy, Tender tender,
            PharmacyOffer pharmacyOffer)
        {
            String body = "<html><body>" +
                          "<p>Hello, " + pharmacy.Name + "</p>" +
                          "<p>You are not winner for our tender \"" + tender.Name + "\"</p>" +
                          "<p>This is medications that you send in offer:</p>" +
                          "<table border=\"1\" style=\"width: 100%\">" +
                          "<tr><th>Medication name</th><th>Quantity</th><th>Price</th></tr>";

            foreach (var pharmacyOfferComponent in pharmacyOffer.Components)
            {
                body += "<tr>" +
                        "<td>" + pharmacyOfferComponent.MedicationName + "</td>" +
                        "<td>" + pharmacyOfferComponent.Quantity + "</td>" +
                        "<td>" + pharmacyOfferComponent.Price + "</td>" +
                        "</tr>";
            }

            body += "</table>";


            body += "<br><p>This tender was closed. Better luck next time. You can try on our other tenders.</p><br>" +
                    "<h1>Best wishes, Bolnica1</h1>";
            body += "</body></html>";
            return body;
        }

        private string GetBodyMessageForWinnerOffer(Pharmacy.Model.Pharmacy pharmacy, Tender tender,
            PharmacyOffer pharmacyOffer)
        {
            String body = "<html><body>" +
                          "<p>Hello, " + pharmacy.Name + "</p>" +
                          "<p>You are winner for our tender \"" + tender.Name + "\"</p><br>" +
                          "<p>This is medications that you send in offer:</p>" +
                          "<table border=\"1\" style=\"width: 100%\">" +
                          "<tr><th>Medication name</th><th>Quantity</th><th>Price</th></tr>";

            foreach (var pharmacyOfferComponent in pharmacyOffer.Components)
            {
                body += "<tr>" +
                        "<td>" + pharmacyOfferComponent.MedicationName + "</td>" +
                        "<td>" + pharmacyOfferComponent.Quantity + "</td>" +
                        "<td>" + pharmacyOfferComponent.Price + "</td>" +
                        "</tr>";
            }

            body += "</table>";
            body += "<h1 align=\"right\">Total price: " + countTotalPrice(pharmacyOffer.Components) + "</h1>";
            body += "<h1>Best wishes, Bolnica1</h1>";
            body += "</body></html>";
            return body;
        }

        private double countTotalPrice(IEnumerable<PharmacyOfferComponent> pharmacyOfferComponents)
        {
            double retVal = 0.0;
            foreach (var pharmacyOfferComponent in pharmacyOfferComponents)
            {
                retVal += pharmacyOfferComponent.Quantity * pharmacyOfferComponent.Price;
            }

            return retVal;
        }
    }
}