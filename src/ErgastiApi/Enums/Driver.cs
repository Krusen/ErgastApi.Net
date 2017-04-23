using ErgastApi.Attributes;

namespace ErgastApi.Enums
{
    public enum Driver
    {
        // TODO: Fix IDs (they are not the 3-letter code)

        /// <summary>Fernando Alonso</summary>
        [Id("alonso")] ALO,
        [Id("alonso")] Alonso,
        /// <summary>Fernando Alonso</summary>
        [Id("ALO")] FernandoAlonso,

        /// <summary>Valtteri Bottas</summary>
        [Id("BOT")] BOT,
        /// <summary>Valtteri Bottas</summary>
        [Id("BOT")] Bottas,
        [Id("BOT")] ValtteriBottas,

        /// <summary>Jenson Button</summary>
        [Id("BUT")] BUT,
        /// <summary>Jenson Button</summary>
        [Id("BUT")] Button,
        [Id("BUT")] JensonButton,

        /// <summary>Marcus Ericsson</summary>
        [Id("ERI")] ERI,
        /// <summary>Marcus Ericsson</summary>
        [Id("ERI")] Ericsson,
        [Id("ERI")] MarcusEricsson,

        /// <summary>
        /// Romain Grosjean
        /// </summary>
        [Id("GRO")] GRO,
        /// <summary>
        /// Romain Grosjean
        /// </summary>
        [Id("GRO")] Grosjean,
        [Id("GRO")] RomainGrosjean,

        /// <summary>
        /// Lewis Hamilton
        /// </summary>
        [Id("HAM")] HAM,
        /// <summary>
        /// Lewis Hamilton
        /// </summary>
        [Id("HAM")] Hamilton,
        [Id("HAM")] LewisHamilton,

        /// <summary>
        /// Nico Hülkenberg
        /// </summary>
        [Id("HUL")] HUL,
        /// <summary>
        /// Nico Hülkenberg
        /// </summary>
        [Id("HUL")] Hulkenberg,
        [Id("HUL")] NicoHulkenberg,

        /// <summary>
        /// Daniil Kvyat
        /// </summary>
        [Id("KVY")] KVY,
        /// <summary>
        /// Danieel Kvyat
        /// </summary>
        [Id("KVY")] Kvyat,
        [Id("KVY")] DaniilKvyat,

        /// <summary>
        /// Kevin Magnussen
        /// </summary>
        [Id("MAG")] MAG,
        /// <summary>
        /// Kevin Magnussen
        /// </summary>
        [Id("MAG")] Magnussen,
        [Id("MAG")] KevinMagnussen,

        /// <summary>
        /// Pastor "Maldozer" Maldonado
        /// </summary>
        [Id("MAL")] MAL,
        /// <summary>
        /// Pastor "Maldozer" Maldonado
        /// </summary>
        [Id("MAL")] Maldonado,
        /// <summary>
        /// Pastor "Maldozer" Maldonado
        /// </summary>
        [Id("MAL")] Maldozer,
        [Id("MAL")] PastorMaldonado,

        /// <summary>
        /// Felipe Mazza
        /// </summary>
        [Id("MAS")] MAS,
        [Id("MAS")] Massa,
        [Id("MAS")] FelipeMassa,

        /// <summary>
        /// Sergio Pérez
        /// </summary>
        [Id("PER")] PER,
        /// <summary>
        /// Sergio Pérez
        /// </summary>
        [Id("PER")] Perez,
        [Id("PER")] SergioPerez,

        /// <summary>
        /// Kimi Räikkönen
        /// </summary>
        [Id("RAI")] RAI,
        /// <summary>
        /// Kimi Räikkönen
        /// </summary>
        [Id("RAI")] Raikkonen,
        [Id("RAI")] KimiRaikkonen,

        /// <summary>
        /// Daniel Ricciardo
        /// </summary>
        [Id("RIC")] RIC,
        /// <summary>
        /// Daniel Ricciardo
        /// </summary>
        [Id("RIC")] Ricciardo,
        [Id("RIC")] DanielRicciardo,

        /// <summary>
        /// Max Verstappen
        /// </summary>
        [Id("VER")] VER,
        /// <summary>
        /// Max Verstappen
        /// </summary>
        [Id("RIC")] Verstappen,
        [Id("RIC")] MaxVerstappen,

        /// <summary>
        /// Nico Rosberg
        /// </summary>
        [Id("ROS")] ROS,
        /// <summary>
        /// Nico Rosberg
        /// </summary>
        [Id("ROS")] Rosberg,
        [Id("ROS")] NicoRosberg,

        /// <summary>
        /// Adrian Sutil
        /// </summary>
        [Id("SUT")] SUT,
        /// <summary>
        /// Adrian Sutil
        /// </summary>
        [Id("SUT")] Sutil,
        [Id("SUT")] AdrianSutil,

        /// <summary>
        /// Sebastian Vettel
        /// </summary>
        [Id("VET")] VET,
        /// <summary>
        /// Sebastian Vettel
        /// </summary>
        [Id("VET")] Vettel,
        [Id("VET")] SebastianVettel
    }
}