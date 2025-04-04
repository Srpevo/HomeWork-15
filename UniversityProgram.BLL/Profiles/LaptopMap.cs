﻿
using UniversityProgram.BLL.Models.CpuModels.ViewModels;
using UniversityProgram.BLL.Models.LaptopModels.AddModels;
using UniversityProgram.BLL.Models.LaptopModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public static class LaptopMap
    {
        public static LaptopModel Map(this Laptop model)
        {
            return new LaptopModel
            {
                Name = model.Name,
                Id = model.Id,
                Cpu = model.Cpu!.Map()
            };
        }

        public static Laptop Map(this LaptopAddModel? model)
        {
            if (model is null) return null!;

            return new Laptop
            {
                Name = model.Name,
                Cpu = model.Cpu.Map() ?? null!
            };
        }

        public static LaptopWithCpuModel MapLaptopWithCpuModel(this Laptop laptop)
        {
            return new LaptopWithCpuModel()
            {
                Id = laptop.Id,
                Name = laptop.Name,
                Cpu = laptop.Cpu is null
                 ? null
                 : new CpuModel()
                 {
                     Id = laptop.Cpu.Id,
                     Name = laptop.Cpu.Name
                 }
            };
        }

    }
}
