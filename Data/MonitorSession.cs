using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CS8618
#pragma warning disable CS8981

public class Column
{
    public string displayName { get; set; }
    public Mapper mapper { get; set; }
    public DisplayParams displayParams { get; set; }
}

public class Config
{
    public List<Matcher> matcher { get; set; }
    public List<PivotItem> pivotItems { get; set; }
    public List<Column> columns { get; set; }
}

public class Context
{
    public string entityName { get; set; }
    public string propertyName { get; set; }
    public DiagnosticContext diagnosticContext { get; set; }
    public int? id { get; set; }
    public int? nodeId { get; set; }
}

public class Data
{
    public Context context { get; set; }
    public string value { get; set; }
    public Request request { get; set; }
    public Response response { get; set; }
    public double? startTime { get; set; }
    public string name { get; set; }
    public double? fetchStart { get; set; }
    public double? domainLookupStart { get; set; }
    public double? domainLookupEnd { get; set; }
    public double? connectStart { get; set; }
    public double? connectEnd { get; set; }
    public double? secureConnectionStart { get; set; }
    public double? requestStart { get; set; }
    public double? responseStart { get; set; }
    public double? responseEnd { get; set; }
    public int? transferSize { get; set; }
    public string nextHopProtocol { get; set; }
    public string info { get; set; }
}

public class DataOperation
{
    public string protocol { get; set; }
    public string operation { get; set; }
    public string dataSource { get; set; }
}

public class DiagnosticContext
{
    public string formula { get; set; }
    public DataOperation dataOperation { get; set; }
    public Span span { get; set; }
}

public class DisplayParams
{
    public string filterType { get; set; }
    public Formatter formatter { get; set; }
}

public class EditorData
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Formatter
{
    public string name { get; set; }
}

public class Formula
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Headers
{
    [JsonPropertyName("x-ms-user-agent")]
    public string xmsuseragent { get; set; }

    [JsonPropertyName("x-ms-client-session-id")]
    public string xmsclientsessionid { get; set; }

    [JsonPropertyName("x-ms-client-request-id")]
    public string xmsclientrequestid { get; set; }

    [JsonPropertyName("x-ms-client-environment-id")]
    public string xmsclientenvironmentid { get; set; }

    [JsonPropertyName("x-ms-client-app-id")]
    public string xmsclientappid { get; set; }

    [JsonPropertyName("x-ms-client-tenant-id")]
    public string xmsclienttenantid { get; set; }

    [JsonPropertyName("x-ms-client-object-id")]
    public string xmsclientobjectid { get; set; }

    [JsonPropertyName("Accept-Language")]
    public string AcceptLanguage { get; set; }
    public string Accept { get; set; }

    [JsonPropertyName("Cache-Control")]
    public string CacheControl { get; set; }

    [JsonPropertyName("x-ms-request-method")]
    public string xmsrequestmethod { get; set; }

    [JsonPropertyName("x-ms-request-url")]
    public string xmsrequesturl { get; set; }

    [JsonPropertyName("accept-ch")]
    public string acceptch { get; set; }

    [JsonPropertyName("content-encoding")]
    public string contentencoding { get; set; }

    [JsonPropertyName("Content-Type")]
    public string ContentType { get; set; }
    public string Date { get; set; }

    [JsonPropertyName("ddd-activityid")]
    public string dddactivityid { get; set; }

    [JsonPropertyName("ddd-authenticatedwithjwtflow")]
    public string dddauthenticatedwithjwtflow { get; set; }

    [JsonPropertyName("ddd-datastore")]
    public string ddddatastore { get; set; }

    [JsonPropertyName("ddd-debugid")]
    public string ddddebugid { get; set; }

    [JsonPropertyName("ddd-servername")]
    public string dddservername { get; set; }

    [JsonPropertyName("ddd-strategyexecutionlatency")]
    public string dddstrategyexecutionlatency { get; set; }

    [JsonPropertyName("ddd-strategyid")]
    public string dddstrategyid { get; set; }

    [JsonPropertyName("ddd-usertype")]
    public string dddusertype { get; set; }
    public string nel { get; set; }
    public string onewebservicelatency { get; set; }

    [JsonPropertyName("report-to")]
    public string reportto { get; set; }

    [JsonPropertyName("timing-allow-origin")]
    public string timingalloworigin { get; set; }
    public string vary { get; set; }

    [JsonPropertyName("x-cache")]
    public string xcache { get; set; }

    [JsonPropertyName("x-fabric-cluster")]
    public string xfabriccluster { get; set; }

    [JsonPropertyName("x-fd-detection-corpnet")]
    public string xfddetectioncorpnet { get; set; }

    [JsonPropertyName("x-fd-features")]
    public string xfdfeatures { get; set; }

    [JsonPropertyName("x-fd-flight")]
    public string xfdflight { get; set; }

    [JsonPropertyName("x-ms-apihub-cached-response")]
    public string xmsapihubcachedresponse { get; set; }

    [JsonPropertyName("x-ms-apihub-obo")]
    public string xmsapihubobo { get; set; }

    [JsonPropertyName("x-msedge-ref")]
    public string xmsedgeref { get; set; }

    [JsonPropertyName("x-msedge-responseinfo")]
    public string xmsedgeresponseinfo { get; set; }
}

public class HighlightEnd
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class HighlightStart
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Mapper
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Mappers
{
    public EditorData editorData { get; set; }
    public Title title { get; set; }
    public HighlightStart highlightStart { get; set; }
    public HighlightEnd highlightEnd { get; set; }
    public Formula formula { get; set; }
    public ResponseBody responseBody { get; set; }
    public TableTitle tableTitle { get; set; }
}

public class Matcher
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Message
{
    public object time { get; set; }
    public string category { get; set; }
    public string name { get; set; }
    public int logLevel { get; set; }
    public Data data { get; set; }
    public string correlationId { get; set; }
}

public class Params
{
    public List<Property> properties { get; set; }
    public string expression { get; set; }
    public string value { get; set; }
}

public class PivotItem
{
    public string template { get; set; }
    public string displayName { get; set; }
    public Mappers mappers { get; set; }
}

public class Property
{
    public string expression { get; set; }
    public string value { get; set; }
}

public class Request
{
    public string url { get; set; }
    public string method { get; set; }
    public Headers headers { get; set; }
    public string body { get; set; }
}

public class Response
{
    public double duration { get; set; }
    public int size { get; set; }
    public int status { get; set; }
    public Headers headers { get; set; }
    public string body { get; set; }
    public string responseType { get; set; }
}

public class ResponseBody
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class MonitorSession
{
    public int Version { get; set; }
    public string SessionId { get; set; }
    public List<Message> Messages { get; set; }
    public List<Config> Config { get; set; }
}

public class Span
{
    public int start { get; set; }
    public int end { get; set; }
}

public class TableTitle
{
    public string engine { get; set; }
    public Params @params { get; set; }
}

public class Title
{
    public string engine { get; set; }
    public Params @params { get; set; }
}