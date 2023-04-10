using OpenAiConsole;

var OpenAIApiClient = new OpenAIApiClient("");
var response = await OpenAIApiClient.SendPrompt("Hellom ChatGPT", "davici");
Console.WriteLine(response);