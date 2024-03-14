
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

var carYears = {
    "0": {
        "A1": [2010, 2024],
        "A3": [1996, 2024],
        "A4": [1994, 2024],
        "A5": [2007, 2024],
        "A6": [1994, 2024],
        "A7": [2010, 2024],
        "A8": [1994, 2024],
        "Q2": [2016, 2024],
        "Q3": [2011, 2024],
        "Q5": [2008, 2024],
        "Q7": [2005, 2024],
        "Q8": [2018, 2024],
        "R8": [2006, 2024],
        "TT": [1998, 2024]
    },
    "1": {
        "DB11": [2016, 2024],
        "DBS Superleggera": [2018, 2024],
        "Vantage": [2005, 2024],
        "DBX": [2020, 2024]
    },
    "2": {
        "Bentayga": [2016, 2024],
        "Continental GT": [2003, 2024],
        "Flying Spur": [2005, 2024]
    },
    "3": {
        "1 Series": [2004, 2024],
        "2 Series": [2013, 2024],
        "3 Series": [1975, 2024],
        "4 Series": [2013, 2024],
        "5 Series": [1972, 2024],
        "6 Series": [1976, 2024],
        "7 Series": [1977, 2024],
        "X1": [2009, 2024],
        "X2": [2017, 2024],
        "X3": [2003, 2024],
        "X4": [2014, 2024],
        "X5": [1999, 2024],
        "X6": [2008, 2024],
        "X7": [2018, 2024],
        "Z4": [2002, 2024]
    },
    "4": {
        "Chiron": [2016, 2024],
        "Divo": [2018, 2024],
        "Centodieci": [2019, 2024],
        "La Voiture Noire": [2019, 2024]
    },
    "5": {
        "Encore": [2012, 2024],
        "Enclave": [2008, 2024],
        "Regal": [1973, 2024],
        "LaCrosse": [2004, 2024]
    },
    "6": {
        "XT4": [2018, 2024],
        "XT5": [2016, 2024],
        "XT6": [2019, 2024],
        "Escalade": [1999, 2024]
    },
    "7": {
        "Spark": [1998, 2024],
        "Sonic": [2011, 2024],
        "Malibu": [1964, 2024],
        "Camaro": [1966, 2024],
        "Corvette": [1953, 2024],
        "Traverse": [2008, 2024],
        "Tahoe": [1994, 2024],
        "Suburban": [1935, 2024],
        "Silverado": [1998, 2024]
    },
    "8": {
        "300": [2004, 2024],
        "Voyager": [1988, 2024]
    },
    "9": {
        "C3": [2002, 2024],
        "C4": [2004, 2024],
        "C5 Aircross": [2018, 2024],
        "Berlingo": [1996, 2024],
        "Cactus": [2014, 2024]
    },
    "10": {
        "Challenger": [1970, 2024],
        "Charger": [1966, 2024],
        "Durango": [1997, 2024]
    },
    "11": {
        "488 GTB": [2015, 2024],
        "812 Superfast": [2017, 2024],
        "SF90 Stradale": [2019, 2024],
        "Portofino": [2018, 2024]
    },
    "12": {
        "500": [1957, 2024],
        "Panda": [1980, 2024],
        "Tipo": [1988, 2024],
        "500X": [2014, 2024]
    },
    "13": {
        "Fiesta": [1976, 2024],
        "Focus": [1998, 2024],
        "Mustang": [1964, 2024],
        "Escape": [2000, 2024],
        "Explorer": [1991, 2024],
        "Expedition": [1997, 2024],
        "Ranger": [1983, 2011],
        "F-150": [1948, 2024]
    },
    "14": {
        "Terrain": [2009, 2024],
        "Acadia": [2007, 2024],
        "Yukon": [1991, 2024]
    },
    "15": {
        "Civic": [1972, 2024],
        "Accord": [1976, 2024],
        "CR-V": [1995, 2024],
        "Pilot": [2002, 2024],
        "Odyssey": [1994, 2024]
    },
    "16": {
        "Accent": [1994, 2024],
        "Elantra": [1990, 2024],
        "Sonata": [1985, 2024],
        "Veloster": [2011, 2024],
        "Kona": [2017, 2024],
        "Tucson": [2004, 2024],
        "Santa Fe": [2000, 2024],
        "Palisade": [2020, 2024]
    },
    "17": {
        "Q50": [2013, 2024],
        "Q60": [2016, 2024],
        "QX50": [2013, 2024],
        "QX60": [2012, 2024],
        "QX80": [2004, 2024]
    },
    "18": {
        "XE": [2015, 2024],
        "XF": [2007, 2024],
        "XJ": [1968, 2019],
        "F-Pace": [2016, 2024],
        "E-Pace": [2018, 2024],
        "I-Pace": [2018, 2024]
    },
    "19": {
        "Renegade": [2014, 2024],
        "Compass": [2006, 2024],
        "Cherokee": [1974, 2024],
        "Grand Cherokee": [1992, 2024],
        "Wrangler": [1986, 2024],
        "Gladiator": [2019, 2024]
    },
    "20": {
        "Rio": [2000, 2024],
        "Forte": [2008, 2024],
        "Optima": [2000, 2024],
        "Stinger": [2017, 2024],
        "Soul": [2008, 2024],
        "Sportage": [1993, 2024],
        "Sorento": [2002, 2024],
        "Telluride": [2019, 2024]
    },
    "21": {
        "Huracan": [2014, 2024],
        "Aventador": [2011, 2024],
        "Urus": [2018, 2024]
    },
    "22": {
        "Defender": [1990, 2016],
        "Discovery Sport": [2014, 2024],
        "Discovery": [1989, 2024],
        "Range Rover Evoque": [2011, 2024],
        "Range Rover Velar": [2017, 2024],
        "Range Rover Sport": [2005, 2024],
        "Range Rover": [1970, 2024]
    },
    "23": {
        "IS": [1998, 2024],
        "ES": [1989, 2024],
        "GS": [1991, 2024],
        "LS": [1989, 2024],
        "RC": [2014, 2024],
        "LC": [2017, 2024],
        "UX": [2018, 2024],
        "NX": [2014, 2024],
        "RX": [1998, 2024],
        "GX": [2002, 2024],
        "LX": [1995, 2024]
    },
    "24": {
        "MKZ": [2006, 2024],
        "Continental": [1939, 2020],
        "Navigator": [1998, 2024],
        "Aviator": [2002, 2005]
    },
    "25": {
        "Ghibli": [2013, 2024],
        "Quattroporte": [1963, 2024],
        "Levante": [2016, 2024],
        "GranTurismo": [2007, 2019],
        "GranCabrio": [2010, 2019]
    },
    "26": {
        "Mazda3": [2003, 2024],
        "Mazda6": [2002, 2024],
        "CX-3": [2015, 2024],
        "CX-30": [2019, 2024],
        "CX-5": [2012, 2024],
        "CX-9": [2006, 2024],
        "MX-5": [1989, 2024]
    },
    "27": {
        "570S": [2015, 2024],
        "720S": [2017, 2024],
        "600LT": [2018, 2024],
        "Senna": [2018, 2024]
    },
    "28": {
        "A-Class": [1997, 2024],
        "C-Class": [1993, 2024],
        "E-Class": [1993, 2024],
        "S-Class": [1954, 2024],
        "CLA": [2013, 2024],
        "CLS": [2004, 2024],
        "GLA": [2013, 2024],
        "GLC": [2015, 2024],
        "GLE": [1997, 2024],
        "GLS": [2006, 2024],
        "G-Class": [1979, 2024],
        "SL": [1954, 2024],
        "SLC": [1996, 2020]
    },
    "29": {
        "Cooper": [1961, 2024],
        "Countryman": [2010, 2024],
        "Clubman": [2007, 2024],
        "Convertible": [2004, 2024]
    },
    "30": {
        "Mirage": [1978, 2024],
        "Eclipse Cross": [2017, 2024],
        "Outlander": [2001, 2024],
        "Outlander Sport": [1991, 2024]
    },
    "31": {
        "Versa": [2006, 2024],
        "Sentra": [1982, 2024],
        "Altima": [1992, 2024],
        "Maxima": [1981, 2024],
        "370Z": [2009, 2024],
        "GT-R": [2007, 2024],
        "Kicks": [2016, 2024],
        "Rogue": [2007, 2024],
        "Murano": [2002, 2024],
        "Pathfinder": [1985, 2024],
        "Armada": [2003, 2024],
        "Frontier": [1997, 2024],
        "Titan": [2003, 2024]
    },
    "32": {
        "Huayra": [2012, 2024],
        "Huayra Roadster": [2017, 2024],
        "Zonda": [1999, 2024],
        "Zonda Roadster": [2003, 2024]
    },
    "33": {
        "208": [2012, 2024],
        "308": [2007, 2024],
        "508": [2010, 2024],
        "2008": [2013, 2024],
        "3008": [2008, 2024],
        "5008": [2009, 2024]
    },
    "34": {
        "911": [1964, 2024],
        "718 Boxster": [1996, 2024],
        "718 Cayman": [2005, 2024],
        "Panamera": [2009, 2024],
        "Macan": [2014, 2024],
        "Cayenne": [2002, 2024],
        "Taycan": [2019, 2024]
    },
    "35": {
        "1500": [1981, 2024],
        "2500": [1981, 2024],
        "3500": [1981, 2024]
    },
    "36": {
        "Clio": [1990, 2024],
        "Megane": [1995, 2024],
        "Captur": [2013, 2024],
        "Kadjar": [2015, 2024],
        "Talisman": [2015, 2024],
        "Koleos": [2008, 2024]
    },
    "37": {
        "Ghost": [2009, 2024],
        "Phantom": [1925, 2024],
        "Wraith": [2013, 2024],
        "Dawn": [2015, 2024],
        "Cullinan": [2018, 2024]
    },
    "38": {
        "Impreza": [1992, 2024],
        "Legacy": [1989, 2024],
        "Outback": [1994, 2024],
        "Forester": [1997, 2024],
        "Crosstrek": [2012, 2024],
        "Ascent": [2018, 2024],
        "WRX": [1992, 2024],
        "BRZ": [2012, 2024]
    },
    "39": {
        "Swift": [1983, 2024],
        "Baleno": [1995, 2024],
        "Ignis": [2000, 2024],
        "Vitara": [1988, 2024],
        "Jimny": [1970, 2024]
    },
    "40": {
        "Model 3": [2017, 2024],
        "Model S": [2012, 2024],
        "Model X": [2015, 2024],
        "Model Y": [2020, 2024]
    },
    "41": {
        "Corolla": [1966, 2024],
        "Camry": [1982, 2024],
        "Prius": [1997, 2024],
        "Mirai": [2014, 2024],
        "Yaris": [1999, 2024],
        "86": [2012, 2024],
        "RAV4": [1994, 2024],
        "Highlander": [2000, 2024],
        "4Runner": [1984, 2024],
        "Sequoia": [2000, 2024],
        "Land Cruiser": [1951, 2024],
        "Tacoma": [1995, 2024],
    },
    "42": {
        "Golf": [1974, 2024],
        "Jetta": [1979, 2024],
        "Passat": [1973, 2024],
        "Arteon": [2017, 2024],
        "Tiguan": [2007, 2024],
        "Atlas": [2017, 2024],
        "Touareg": [2002, 2024]
    },
    "43": {
        "S60": [2000, 2024],
        "S90": [2016, 2024],
        "V60": [2010, 2024],
        "V90": [2016, 2024],
        "XC40": [2017, 2024],
        "XC60": [2008, 2024],
        "XC90": [2002, 2024]
    }
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

            // Populate year select based on selected model
            populateYears(brandSelect.value, this.value);
        } else {
            yearSelect.disabled = true;
        }

        // Reset year select when model changes
        yearSelect.value = "";
    });

    function populateModels(brand)
    {
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

    function populateYears(brand, model) {
        console.log("Brand:", brand);
        console.log("Model:", model);

        // Clear existing options
        yearSelect.innerHTML = '<option value="">--Select Year--</option>';

        // Check if the brand exists in carYears
        if (!carYears.hasOwnProperty(brand)) {
            console.log("Brand not found:", brand);
            return;
        }

        // Check if the model exists for the brand
        if (!carYears[brand].hasOwnProperty(model)) {
            console.log("Model not found for brand:", model);
            return;
        }

        // Get start and end years for the selected model
        var [startYear, endYear] = carYears[brand][model];

        // Populate year select with options
        for (var year = startYear; year <= endYear; year++) {
            var option = new Option(year.toString(), year.toString());
            yearSelect.add(option);
        }
    }


});


