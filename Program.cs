using System;

class Program
{
static void Main(string[] args)
{
string estado = "Procurando";
bool eliminado = false;
bool ferido = false;
bool inimigoProximo = false;
int transicoes = 0;

while (estado != "Morto")
{
Random random = new Random();
transicoes++;
Console.WriteLine($"Estado atual: {estado}");

if (estado == "Procurando")
{
    if (eliminado == false || ferido || inimigoProximo == false)
    {
        if (random.NextDouble() < 0.5)
        {
        ferido = false;
        Console.WriteLine("NPC se curou.");
        }
        else
        {
        inimigoProximo = true;
        Console.WriteLine("NPC encontrou um inimigo.");
        estado = "Atacando";
        }
    }
    else
    {
        if (random.NextDouble() < 0.5)
        {
        ferido = true;
        Console.WriteLine("NPC se feriu gravemente.");
            if (random.NextDouble() < 0.5)
            {
            eliminado = true;
            Console.WriteLine("NPC morreu devido ao ferimento.");
            estado = "Morto";
            }
            else
            {           
            inimigoProximo = false;
            Console.WriteLine("NPC matou o inimigo ou o inimigo fugiu.");
            estado = "Procurando";
            }
        }
        else
        {
        inimigoProximo = false;
        Console.WriteLine("NPC matou o inimigo ou o inimigo fugiu.");
        estado = "Procurando";
        }
    }
}

else if (estado == "Atacando")
{
if (eliminado)
{
Console.WriteLine("NPC foi eliminado.");
estado = "Morto";
}
else if (ferido)
{
Console.WriteLine("NPC está ferido e não pode atacar.");
    if (random.NextDouble() < 0.25)
    {
    eliminado = true;
    Console.WriteLine("NPC morreu devido ao ferimento.");
    estado = "Morto";
    }
    else
    {
    estado = "Fugindo";
    }
}
else if (inimigoProximo)
{
    if (random.NextDouble() < 0.5)
    {
    ferido = true;
    Console.WriteLine("NPC se feriu gravemente.");
        if (random.NextDouble() < 0.5)
        {
        eliminado = true;
        Console.WriteLine("NPC morreu devido ao ferimento.");
        estado = "Morto";
        }
        else
        {
        inimigoProximo = false;
        Console.WriteLine("NPC matou o inimigo ou o inimigo fugiu.");
        estado = "Procurando";
        }
    }
    else
    {
    inimigoProximo = false;
    Console.WriteLine("NPC matou o inimigo ou o inimigo fugiu.");
    estado = "Procurando";
    }
}
else
{
estado = "Procurando";
}
}

else if (estado == "Fugindo")
{
if (eliminado)
{
Console.WriteLine("NPC foi eliminado.");
estado = "Morto";
}
else if (ferido)
{
if (random.NextDouble() < 0.25)
    {
    eliminado = true;
    Console.WriteLine("NPC morreu devido ao ferimento.");
    estado = "Morto";
    }
    else
    {
    ferido = false;
    Console.WriteLine("NPC se curou.");
    estado = "Fugindo";
    }
}
else
{

if (random.NextDouble() < 0.5)
{
inimigoProximo = false;
Console.WriteLine("Inimigo desistiu da perseguição.");
}

if (random.NextDouble() < 0.5)
{
ferido = true;
Console.WriteLine("NPC se feriu gravemente.");
    if (random.NextDouble() < 0.5)
    {
    eliminado = true;
    Console.WriteLine("NPC morreu devido ao ferimento.");
    estado = "Morto";
    }
else
    {
    estado = "Fugindo";
    }
}

else
{
estado = "Procurando";
}
}
}
}

Console.WriteLine($"O NPC sobreviveu por {transicoes} transições.");
}
}

