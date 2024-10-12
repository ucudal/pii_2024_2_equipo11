using Library.Combate;

namespace Ucu.Poo.Program.Tests;

[TestFixture]
public class BatallaTests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IniciarBatalla()
    {
        Batalla PruebaBatalla = new Batalla();
        PruebaBatalla.IniciarBatalla();
        bool EstadoBatallaEsperado = true;
        bool ResultadoPrueba=PruebaBatalla.GetEstadoBatalla();
        Assert.AreEqual(EstadoBatallaEsperado,ResultadoPrueba);
    }

    [Test]
    public void TerminarBatallaConAmbosEquiposVivos()
    {
        Batalla PruebaBatalla1 = new Batalla();
        string ResultadoEsperado = "La batalla sigue, ningun equipo ha perdido por completo!";
        string ResultadoDado= PruebaBatalla1.TerminarBatalla();
        Assert.AreEqual(ResultadoEsperado,ResultadoDado);
    }
    
    [Test]
    public void AvanzarTurnoConBatallaTerminada()
    {
        Batalla PruebaBatalla2 = new Batalla();
        PruebaBatalla2.TerminarBatalla();
        string ResultadoEsperado = "Ya ha terminado la batalla!";
        string ResultadoDado=PruebaBatalla2.AvanzarTurno();
        Assert.AreEqual(ResultadoEsperado,ResultadoDado);
    }
}