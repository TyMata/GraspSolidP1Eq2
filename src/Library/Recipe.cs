//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total del producto es: ${GetProductionCost()}");
        }
        /*
        Añadimos esta responsabilidad a Recipe porque cumple con el patrón Expert ya 
        que es la clase que tiene la información sobre todos los steps realizados.
        Al hacer esto rompemos con el principio SRP pero es necesario hacerlo ya que 
        la variable que guarda todos estos steps es privada, osea que no podemos
        acceder a esta información desde otra clase.
        */
        private double GetProductionCost()
        {
            double CostoInsumos = 0;
            double CostoEquipamiento = 0;
            foreach (Step step in this.steps)
            {
                CostoInsumos += step.Input.UnitCost * step.Quantity; //Costo insumos
                CostoEquipamiento += step.Equipment.HourlyCost * (step.Time/60) ; //Costo equipamiento
            }
            return CostoInsumos + CostoEquipamiento;
        }
    }
}