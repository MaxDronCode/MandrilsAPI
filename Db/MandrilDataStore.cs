﻿using MandrilAPI.Enums;
using MandrilAPI.Models;

namespace MandrilAPI.Db;

public class MandrilDataStore
{
    public List<Mandril> Mandrils { get; set; }

    public static MandrilDataStore Current { get; } = new MandrilDataStore();

    public MandrilDataStore()
    {
        Mandrils = new List<Mandril>()
        {
            new Mandril()
            {
                Id = 1,
                Name = "Mini Mandril",
                Surname = "Fernandez",
                Habilities = new List<Hability>()
                {
                    new Hability()
                    {
                        Id = 1,
                        Name = "Revolcarse",
                        Potency = EPotency.Suave
                    },
                    new Hability()
                    {
                        Id = 2,
                        Name = "Saltar",
                        Potency = EPotency.Moderado
                    }
                }
            },
            new Mandril()
            {
                Id = 2,
                Name = "SuperMandril",
                Surname = "Rodríguez",
                Habilities = new List<Hability>()
                {
                    new Hability()
                    {
                        Id = 1,
                        Name = "Mirar Intensamente",
                        Potency = EPotency.Intenso
                    },
                    new Hability()
                    {
                        Id = 2,
                        Name = "Dormir",
                        Potency = EPotency.RePotente
                    }
                }
            },
            new Mandril()
            {
                Id = 3,
                Name = "MegaMandril",
                Surname = "González",
                Habilities = new List<Hability>()
                {
                    new Hability()
                    {
                        Id = 1,
                        Name = "Comer",
                        Potency = EPotency.Extremo
                    },
                    new Hability()
                    {
                        Id = 2,
                        Name = "Vomitar",
                        Potency = EPotency.Suave
                    }
                }
            }
        };
    }
}