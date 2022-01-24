using RestSharp;
using RestSharp.Serializers;

var options = new RestClientOptions("https://cargo.rzd.ru/dcalc/distance")
{
    ThrowOnAnyError = true,
    Timeout = -1
};

var client = new RestClient(options);

var request = new RestRequest().AddStringBody("{\"fromStationCode\":\"035404\",\"toStationCode\":\"035404\"}", ContentType.Json);
//var request = new RestRequest().AddJsonBody(new RwRequest { fromStationCode = "035404", toStationCode = "035404" });
request.AddHeader("Content-Type", "application/json;charset=UTF-8");
request.AddHeader("Accept", "application/json;charset=UTF-8");

var result = await client.PostAsync<RwResponse>(request);

Console.WriteLine("result " + result);


//{"result":"OK","data":{"fromStationCode":"035404","toStationCode":"790304","fromStationName":"АВТОВО (ПЕРЕВ.)","toStationName":"ВОЙНОВКА-ПЕРЕВАЛКА","deliveryDistance":2434,"deliveryPeriod":12,"requestDate":"2022-01-24 17:40:06"}}
public record RwResponse
{
    public string result { get; set; }

    public RwResponseData data { get; set; }
}

public record RwRequest
{
    public string fromStationCode { get; set; }
    public string toStationCode { get; set; }
}

public record RwResponseData
{
    public string fromStationCode { get; set; }
    public string fromStationName { get; set; }
    public string toStationCode { get; set; }
    public string toStationName { get; set; }
    public int deliveryDistance { get; set; }
    public int deliveryPeriod { get; set; }
}