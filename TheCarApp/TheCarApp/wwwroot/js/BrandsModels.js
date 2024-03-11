// carData.js

// carData.js

var carModels = {
    "0": ["A1", "A3", "A4", "A5", "A6", "A7", "A8", "Q2", "Q3", "Q5", "Q7", "Q8", "R8", "TT"],
    "1": ["DB11", "DBS Superleggera", "Vantage", "DBX"],
    "2": ["Bentayga", "Continental GT", "Flying Spur"],
    "3": ["1 Series", "2 Series", "3 Series", "4 Series", "5 Series", "6 Series", "7 Series", "X1", "X2", "X3", "X4", "X5", "X6", "X7", "Z4"],
    "4": ["Chiron", "Divo", "Centodieci", "La Voiture Noire"],
    "5": ["Encore", "Enclave", "Regal", "LaCrosse"],
    "6": ["XT4", "XT5", "XT6", "Escalade"],
    "7": ["Spark", "Sonic", "Malibu", "Camaro", "Corvette", "Traverse", "Tahoe", "Suburban", "Silverado"],
    "8": ["300", "Voyager"],
    "9": ["C3", "C4", "C5 Aircross", "Berlingo", "Cactus"],
    "10": ["Challenger", "Charger", "Durango"],
    "11": ["488 GTB", "812 Superfast", "SF90 Stradale", "Portofino"],
    "12": ["500", "Panda", "Tipo", "500X"],
    "13": ["Fiesta", "Focus", "Mustang", "Escape", "Explorer", "Expedition", "Ranger", "F-150"],
    "14": ["Terrain", "Acadia", "Yukon"],
    "15": ["Civic", "Accord", "CR-V", "Pilot", "Odyssey"],
    "16": ["Accent", "Elantra", "Sonata", "Veloster", "Kona", "Tucson", "Santa Fe", "Palisade"],
    "17": ["Q50", "Q60", "QX50", "QX60", "QX80"],
    "18": ["XE", "XF", "XJ", "F-Pace", "E-Pace", "I-Pace"],
    "19": ["Renegade", "Compass", "Cherokee", "Grand Cherokee", "Wrangler", "Gladiator"],
    "20": ["Rio", "Forte", "Optima", "Stinger", "Soul", "Sportage", "Sorento", "Telluride"],
    "21": ["Huracan", "Aventador", "Urus"],
    "22": ["Defender", "Discovery Sport", "Discovery", "Range Rover Evoque", "Range Rover Velar", "Range Rover Sport", "Range Rover"],
    "23": ["IS", "ES", "GS", "LS", "RC", "LC", "UX", "NX", "RX", "GX", "LX"],
    "24": ["MKZ", "Continental", "Navigator", "Aviator"],
    "25": ["Ghibli", "Quattroporte", "Levante", "GranTurismo", "GranCabrio"],
    "26": ["Mazda3", "Mazda6", "CX-3", "CX-30", "CX-5", "CX-9", "MX-5"],
    "27": ["570S", "720S", "600LT", "Senna"],
    "28": ["A-Class", "C-Class", "E-Class", "S-Class", "CLA", "CLS", "GLA", "GLC", "GLE", "GLS", "G-Class", "SL", "SLC"],
    "29": ["Cooper", "Countryman", "Clubman", "Convertible"],
    "30": ["Mirage", "Eclipse Cross", "Outlander", "Outlander Sport"],
    "31": ["Versa", "Sentra", "Altima", "Maxima", "370Z", "GT-R", "Kicks", "Rogue", "Murano", "Pathfinder", "Armada", "Frontier", "Titan"],
    "32": ["Huayra", "Huayra Roadster", "Zonda", "Zonda Roadster"],
    "33": ["208", "308", "508", "2008", "3008", "5008"],
    "34": ["911", "718 Boxster", "718 Cayman", "Panamera", "Macan", "Cayenne", "Taycan"],
    "35": ["1500", "2500", "3500"],
    "36": ["Clio", "Megane", "Captur", "Kadjar", "Talisman", "Koleos"],
    "37": ["Ghost", "Phantom", "Wraith", "Dawn", "Cullinan"],
    "38": ["Impreza", "Legacy", "Outback", "Forester", "Crosstrek", "Ascent", "WRX", "BRZ"],
    "39": ["Swift", "Baleno", "Ignis", "Vitara", "Jimny"],
    "40": ["Model 3", "Model S", "Model X", "Model Y"],
    "41": ["Corolla", "Camry", "Prius", "Mirai", "Yaris", "86", "RAV4", "Highlander", "4Runner", "Sequoia", "Land Cruiser", "Tacoma", "Tundra"],
    "42": ["Golf", "Jetta", "Passat", "Arteon", "Tiguan", "Atlas", "Touareg"],
    "43": ["S60", "S90", "V60", "V90", "XC40", "XC60", "XC90"]
};


document.addEventListener("DOMContentLoaded", function () {
    var brandSelect = document.getElementById("brand");
    var modelSelect = document.getElementById("model");
    var yearSelect = document.getElementById("year");

    // Log to ensure brandSelect, modelSelect, and yearSelect are correctly obtained
    console.log("brandSelect:", brandSelect);
    console.log("modelSelect:", modelSelect);
    console.log("yearSelect:", yearSelect);

    brandSelect.addEventListener("change", function () {
        var selectedBrand = this.value; // Get the selected brand value
        if (selectedBrand !== "") {
            // Enable model select
            modelSelect.disabled = false;

            // Populate model select based on selected brand
            populateModels(selectedBrand);
        } else {
            modelSelect.disabled = true;
            yearSelect.disabled = true;
        }

        // Reset model and year selects when brand changes
        modelSelect.value = "";
        yearSelect.value = "";
    });

    modelSelect.addEventListener("change", function () {
        if (this.value !== "") {
            yearSelect.disabled = false;
        } else {
            yearSelect.disabled = true;
        }

        // Reset year select when model changes
        yearSelect.value = "";
    });

    function populateModels(brand) {
        // Clear existing options
        modelSelect.innerHTML = '<option value="">--Select Model--</option>';

        // Get models for selected brand from carModels data structure
        var models = carModels[brand];

        // Log to ensure models is correctly obtained
        console.log("models for", brand + ":", models);

        // Populate model select with options
        models.forEach(function (model) {
            var option = document.createElement("option");
            option.text = model;
            option.value = model;
            modelSelect.add(option);
        });
    }
});

