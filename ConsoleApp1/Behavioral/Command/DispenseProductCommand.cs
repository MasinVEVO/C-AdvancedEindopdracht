﻿using VendingMachineApp.Models;

namespace MyApp.Behavioral.Command;

public class DispenseProductCommand : ICommand
{
    
    /// <summary>
    /// Command die zorgt voor het uitgeven van een product uit de automaat.
    /// Implementeert het Command patroon om een product uitgifte operatie te encapsuleren.
    /// </summary>
        // Referentie naar de automaat die het product zal uitgeven
        private readonly VendingMachine _vendingMachine;
        // Naam van het product dat uitgegeven moet worden
        private readonly string _product;

        /// <summary>
        /// Initialiseert een nieuwe instantie van DispenseProductCommand
        /// </summary>
        /// <param name="vendingMachine">De automaat die het product zal uitgeven</param>
        /// <param name="product">De naam van het product dat uitgegeven moet worden</param>
        public DispenseProductCommand(VendingMachine vendingMachine, string product)
        {
            _vendingMachine = vendingMachine;
            _product = product;
        }

        /// <summary>
        /// Voert het commando uit, geeft het gespecificeerde product uit
        /// </summary>
        public void Execute()
        {
            _vendingMachine.DispenseProduct(_product);
        }
        
        
}