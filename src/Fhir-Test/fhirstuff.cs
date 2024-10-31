 using Hl7.Fhir.Model; 
 using Hl7.Fhir.Serialization; 
 using Hl7.Fhir.Rest;
using System.Security.Cryptography;

public class FhirStuff 
 {
    private string fhirUri = "https://opendemo.wenotest.com/fhir/rest/v1/fhir/"; 
    public async Task<List<Patient>> GetAllPatients() 
    {
        var fhirClient = new FhirClient(fhirUri)
        {
            Settings = new FhirClientSettings(){
                PreferredFormat = ResourceFormat.Json,
                ReturnPreference =  ReturnPreference.Representation
            }
        }; 

        fhirClient.RequestHeaders?.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJzODFpc2htT0RoNGRKeVN5S2F3Um1oRkk3b0p1azBUSzNXZUNWQlBpbGFVIn0.eyJleHAiOjE3MzAzMjUwMTMsImlhdCI6MTczMDMyNDcxMywianRpIjoiNzhjNjVkMjEtZWZkNS00YWI1LWFkMTMtMGNhN2VhNTk2NzZiIiwiaXNzIjoiaHR0cHM6Ly9vcGVuZGVtby53ZW5vdGVzdC5jb20vc3BpbmUtaWRwL3JlYWxtcy9zYW5kYm94IiwiYXVkIjoiYWNjb3VudCIsInN1YiI6IjI0NGRjMTRlLWYzZTAtNDNmOC1hYjczLWMzMGEzN2Y3Y2UzNSIsInR5cCI6IkJlYXJlciIsImF6cCI6ImRlbW9ncmFwaGljcyIsImFjciI6IjEiLCJhbGxvd2VkLW9yaWdpbnMiOlsiKiJdLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1zYW5kYm94Iiwib2ZmbGluZV9hY2Nlc3MiLCJ1bWFfYXV0aG9yaXphdGlvbiJdfSwicmVzb3VyY2VfYWNjZXNzIjp7ImFjY291bnQiOnsicm9sZXMiOlsibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdfSwiZGVtb2dyYXBoaWNzIjp7InJvbGVzIjpbIkRFTU9HUkFQSElDU19TRUFSQ0giLCJERU1PR1JBUEhJQ1NfUkVBRCJdfX0sInNjb3BlIjoicHJvZmlsZSBkZW1vZ3JhcGhpY3MgZW1haWwiLCJjbGllbnRIb3N0IjoiMjAuMjUxLjExOS4xMDEiLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsInByZWZlcnJlZF91c2VybmFtZSI6InNlcnZpY2UtYWNjb3VudC1kZW1vZ3JhcGhpY3MiLCJjbGllbnRBZGRyZXNzIjoiMjAuMjUxLjExOS4xMDEiLCJjbGllbnRfaWQiOiJkZW1vZ3JhcGhpY3MifQ.NmI7PlH0u5PzibI1mfmYDCuQUw5K-WJ_Vh--zvOb8EpJQn0t0_DCdXEuEHWmbHmjBGoTQxp0cLhpYW4J-_mgBd8AAs-QVLAJe7cccQUOprFH0GfgA-9s6NenIn9ViQIPm5vOvghN-E0CZJGtkpP4qHIRACi4oginRL_IGp8FoHC6lmtsMNc8UdvCycgA3FrYWGGBOITe5gku4AZjf8rjQOzoVJI4pwNWzLZS3mSTHhhX5ubeMOp2TGnxKLbu5o3liuZruvF-Yr5zDpB3ta6lk7CqQWuLdA7nep58MS7T66LIHg4lLLM0pBSc0S3wJAOdPzFFbWvYTZJTRnyz50ccxg");
        List<Patient> patientList = new List<Patient>(); 
        Bundle? patientBundle = await fhirClient.SearchAsync<Patient>();//new string[]{"name=test"}); 
        if(patientBundle is not null)
        {
            System.Console.WriteLine($"- patientBundle totalt results: {patientBundle.Total} Entry count: {patientBundle.Entry.Count}");
            
            foreach(Bundle.EntryComponent entry in patientBundle.Entry)
            {
                System.Console.WriteLine($" - Entry {entry.FullUrl}");
                if(entry.Resource is not null) 
                {
                    Patient patient = (Patient)entry.Resource; 
                    patientList.Add(patient); 
                }
            }
        }
        
        return patientList; 
    }
 }