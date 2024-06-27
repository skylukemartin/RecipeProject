/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://stackoverflow.com/a/58733847
///             https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/
/// </summary>

using System;
using static RecipeProject.Models.Volume;

namespace RecipeProject.Models
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class represents an ingredient, including its name, amount, and unit of measurement.
    /// </summary>
    public class Ingredient
    {
        // Declare ingredient's member variables
        /// <summary>
        /// Name of ingredient.
        /// </summary>
        public string Name { get; set; }

        // Internal member variables
        float _scale;
        Volume.Unit _initialUnit;
        float _initialUnitQuantity;
        float _initialCalories;

        /// <summary>
        /// Volumetric unit of measurement.
        /// </summary>
        public Volume.Unit Unit { get; set; }

        /// <summary>
        /// Quantity in terms of volumetric unit of measurement.
        /// </summary>
        public float UnitQuantity { get; set; }

        /// <summary>
        /// Calories in ingredient.
        /// </summary>
        public float Calories { get; set; }

        /// <summary>
        /// Food group that ingredient belongs to.
        /// </summary>
        public string FoodGroup { get; set; }

        /// <summary>
        /// Scale factor for all scalable properties of the ingredient.
        /// Setting this immediately applies the scale factor to properties.
        /// </summary>
        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                if (_scale == 1)
                {
                    UnitQuantity = _initialUnitQuantity;
                    Unit = _initialUnit;
                    Calories = _initialCalories;
                }
                else
                {
                    var quantityML = (_scale * _initialUnitQuantity * (float)_initialUnit);
                    Unit = Volume.FindBestUnit(quantityML);
                    UnitQuantity = quantityML / (float)Unit;
                    Calories = _scale * _initialCalories;
                }
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Ingredient constructor.
        /// </summary>
        /// <param name="name">Name of ingredient.</param>
        /// <param name="unit">Volumetric unit of measurement.</param>
        /// <param name="unitQuantity">Quantity in terms of volumetric unit of measurement.</param>
        /// <param name="calories">Calories in ingredient.</param>
        /// <param name="foodGroup">Food group that ingredient belongs to.</param>
        public Ingredient(
            string name,
            Volume.Unit unit,
            float unitQuantity,
            float calories,
            string foodGroup,
            float scale = 1
        )
        {
            Name = name;
            _initialUnit = unit;
            _initialUnitQuantity = unitQuantity;
            _initialCalories = calories;
            Scale = scale; // Setting this also sets and scales all scalable properties.
            FoodGroup = foodGroup;
        }

        public void UpdateScale(float scale) => Scale = scale;
    }
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~FILE END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
