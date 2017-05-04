using ErgastApi.Attributes;

namespace ErgastApi.Enums
{
    public enum ConstructorId
    {
        [Id("ferrari")]
        Ferrari,

        [Id("mclaren")]
        McLaren,

        [Id("haas")]
        Haas,

        [Id("force_india")]
        ForceIndia,

        [Id("mercedes")]
        Mercedes,

        [Id("red_bull")]
        RedBull,

        [Id("renault")]
        Renault,

        [Id("sauber")]
        Sauber,

        [Id("toro_rosso")]
        ToroRosso,

        [Id("williams")]
        Williams
    }
}
