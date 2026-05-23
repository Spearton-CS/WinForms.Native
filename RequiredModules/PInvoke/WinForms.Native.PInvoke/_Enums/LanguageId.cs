namespace WinForms.Native.PInvoke;

[Flags]
public enum LanguageId : ushort
{
    // --- Special / Neutral ---
    Neutral = 0x0000,
    Invariant = 0x007f,
    UserDefault = 0x0400,
    SystemDefault = 0x0800,

    // --- Balkan / Slavic ---
    SerbianLatin = 0x081a,
    SerbianCyrillic = 0x0c1a,
    Croatian = 0x041a,
    BosnianLatin = 0x141a,
    Slovenian = 0x0424,
    Russian = 0x0419,
    Ukrainian = 0x0422,
    Bulgarian = 0x0402,
    Polish = 0x0415,
    Czech = 0x0405,
    Slovak = 0x041b,

    // --- West Germanic ---
    EnglishUS = 0x0409,
    EnglishUK = 0x0809,
    EnglishCanada = 0x1009,
    EnglishAustralia = 0x0c09,
    German = 0x0407,
    GermanSwiss = 0x0807,
    GermanAustria = 0x0c07,
    Dutch = 0x0413,
    DutchBelgian = 0x0813,

    // --- Romance ---
    French = 0x040c,
    FrenchSwiss = 0x100c,
    FrenchCanadian = 0x0c0c,
    Italian = 0x0410,
    ItalianSwiss = 0x0810,
    SpanishSpainModern = 0x0c0a,
    SpanishMexico = 0x080a,
    SpanishUS = 0x540a,
    PortugueseBrazil = 0x0416,
    PortuguesePortugal = 0x0816,
    Romanian = 0x0418,

    // --- Northern Europe ---
    Swedish = 0x041d,
    NorwegianBokmal = 0x0414,
    Danish = 0x0406,
    Finnish = 0x040b,
    Estonian = 0x0425,
    Latvian = 0x0426,
    Lithuanian = 0x0427,

    // --- Asian / Pacific ---
    Japanese = 0x0411,
    Korean = 0x0412,
    ChineseSimplified = 0x0804, // Mainland (PRC)
    ChineseTraditional = 0x0404, // Taiwan
    ChineseHongKong = 0x0c04,
    Vietnamese = 0x042a,
    Thai = 0x041e,
    Hindi = 0x0439,

    // --- Middle East / Other ---
    ArabicSaudiArabia = 0x0401,
    ArabicUAE = 0x3801,
    Hebrew = 0x040d,
    Turkish = 0x041f,
    Greek = 0x0808,
    Hungarian = 0x040e
}