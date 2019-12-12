﻿using System;
using System.Linq;

namespace _08._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/8
        /// Photoshop eat your heart out. More Linq abuse. Group by combined with the index parameter of Select is really nice.
        /// </summary>
        static void Main()
        {
            var input = "222222222222222122222222222222022221202022222202222222222222122022222220220220202202222022220222221222220120222222012222120202201022222222222212221222222222222222222122222222222222022221202022022222221222222220222122222221221220222212222022222222221212221021222222102222120212221022222222222221220222222202222222222222222222222222222220212022120212222222222220222022222220222222222212222222221222221212222021222222102222220222200222222222222222220222222212222222222222222222222222122221222122020202222222222221122122222221222220222222222122220222220202222121222222102222220211211222222222222221220222222222222222222222222222222222122221202022221202220222222221122222222221220220222212222022220222221202222120222222202222220202212022222222222212220222222222222222222122222222222222122221222122022222221222222222022122222221222220212202222122222222221212220120222222222222121222212022222222222202221222222212222222222022222222222222022220212022120202220222222222222122222221222220212222222222222222220202222022222222112222022221221222222222222220222222222212222222222122222222222222222220212022020202222222222221222122222222220221212202222222222222221202222221222222112222020221202022222222222212222222222222222222222022222222222222122221212222020202220222222220022122222220220221202202222022221222222222220221222222112222222202210122222222222221222222222212222222222022222222222222022222222122222202220222222221122122222222221222222202222222220222220212220021222222202022220200220122222222222211221222222222222222222022222222222222122222222222221202221222222222022022222221221220202202222222220222220202222221222222202122022210222122222222222212222222222212222222222022122222222222022222202222022222220222222222022022222220220220222202222222220222222222220220222222002222220211220222222222221211222222222212222222220022022222222222122220202122220212220222222221222022222222220221222212222122220222221202221221222222212122020200212022222222220200220222222212222222222122222222222222022220222222220212222222222222022222222220221221212212222022222222222202222121222222022122120211211022222222220202222222222212222222220022222222222222022220202222210222221222222222122222222222222221212212222022220222222212221021222222012122122220202021222222221221222222222222222222222122022222222222222221202022201202220222222221222122222221222221202212222222222222221202221121222222122222220222222121222222221220221222222212222222220122022222222222022222222022110122221222222221222122222220222221222202222222220222222202221222222222202222221211221222222222221201221222222202222222221222222222222222022221212122021222220222222222222222222221220221212212222222220222220212221021222222202222121210212221222222220201220222222202222222221022022222222222122221212222020102221222222221122222222222221221212212222122220222222212220222222222212022021210220222222222222201221222222212222222220222222222222222222220212122202222222212222222022222222221220222202212222222220222221222222122222222212022122222210221222222222220222222222222222222221022022202222222222220202122022202222202222222122122222221221222222202222022220222222212222121222222102022220220221220222222220211221222222202222222220022122212222222122222212222110112220212222221122022222222220222212212222222220222220222221020222222002222121220221020222222220221220222222212222222222022122202222222222221222022001102220202222221222022222220222220222212222022220222222212222220202222222122220201212021222222221210220222222202222222221122222212222222122220222122121112222202222222122222222220222222222212222022221222220212222122202222222022120210202222222222222200220222222202222222220122022212222222222220212222200102221202222222222022222220222221212222222222222222221202222020202222212220121221221011222222221222221222222211222222221022022212222222122220202122001202220202222221022022222220220221222222222022221222221222220020212222012220121212201100222222222201221222222221222222221222122202222222222222212202221202222202222221122122222221221222212222222022220222221222220022212222002020222101202000222222220210221222222220222222220022222202222222222222222112121012221102222221222222222222221222202212222122221222220222221221212222122220220201212202222222221222220222122211222222221022122222222222222222202102221002222122222220122022222221222220212212222222220222221202221220202222202220120202222010222222220210222222122220222222220022122202222222222221212212021100221022222221122122222221221222222202222022220222222222220122212222212121021101222002222222220222222222102200222222221222022202222222122220212012220210222202222220222222222222222221222202222022222222220202221120222222002120121202210022222222220221221222202220222222220022202202222222122220212112012001220222222220222122222221221220222222222122221222222202220120222222122122221200212101222222222200220222002201222222222222122202222222122220222022121121122112222221122222222222222221212212222122222222221222222222211222002121022012220120222222220212220222002210222222220122122212222222122220202112020010122212222222222202222220221222202202222122222222222212222020222222122020020201221220222222222222221222202202222222221222002202222222022222222112211010221112222222022122222222220221202202222122221222222212221022202222012121020220201000222222221212221222112220222222220222202222222222222221202012221010122102222220122002222221221222222222222122222222222212221220222222112020220010202001222222222212221222202202222222220122102222222222222222202222201222120222222220222002222220220220212212222022220222221202220222220222012221021010220201222222221212222222010201222222222122202202222222022222202112120001020222222221022212222221222221212222222222220222220222222220221222112220222100202110222222220202220222221212222222222122022212222222122221202202201202022212222220222122222222222222222212222222222222222212220022211222002221222000210121222222222100222222212211222222222222112212222222222221222022110111222022222222122012222222222221212212222022221222222222221222210222012120121021221002222222222122222222100212222222221122112212222222222220202012010102022012222222022112222220221221222202222222221222220202220220212222122022021122211210222222221201201222202210222222221022222202222222022220221002020001120022222221122102222221221222212202222122222222222202220020201222122122020211211222222222222020221222211221222222220022022222222222022220210122221121122222222220122022222220220222222202212022222222222212221221222222212022222221210111222222220102212222102200222222221222122222222222022221222002200100020112222220022202222222220220202212222022221222221202220022222222102120022111200010222222220112202222112201222222220222022222222222222222200202011201122202222221122122222220220220202202202022222222222222222220221222012122121002221020222222220020212222201202222222220022122202222222222220210102010102221102222222122122222220221221212202202222221222221202220222211222022220220122201220222222221100200222011202222222202122122222222220122221221102120021021202222221122112222220221221212222202022222222220202222022201222102222120121222120222222221022211222211211222222201122202212222220222220221002221011221202222220222002220220220222212212222022222222222222222222202222102222221122211022222222220002210222220210222222200122112212222221222222201212101012020002222220222222221222221220202212222022221222222202222221220222022120220022211111222222222022202222220211222222221022112212222222222222220002212012122102222221222122220221222220212222202222221222220202220221222222210222122020202112222222220211201222021210222222212222122212222221122120202202201012122002222222222102220222221221222222202122220222220222220220211222200122021002212002212222220220220220020210222222221222112222222221022021222002000200020202222221122002221221220222212202212222220222222212020022222222000220121211212121212222222102201221221212222222211122212222222222222122210212222102221202222222022002220221221222202202200122221222221202221221220222222021121002220210212222220020210222112220222222211122012202222220022020221022221220222102222222220212221222222220122202200022221222222222220021201222101121222122200022222222022101210220212221222222202222012202222222022021210202020012021222222220221002221221220222122202222022220222220202022022220222111020121121202110212212221200220220012202222222212122002212222221122120200012201221121112222221122202220220220221112222212222220222220222022122210222210122022120212120222202121102222221210210222222220022012222222220022221200212220210121112222221121022220220222220112222202022220222221202022121222222101120022010210200202212122221212221012222222222210222222222222220222220212102011222221202222221021222220221222220212222200222221222222222022221220222220220220212212120202211021222200220102220222222200022002202212222222020212122220202120102222220022112222221220222012212201222221222221222221221211222020120120210211211202222020112201221002201222222212122212202202220222121201212200022221222222222121122222220222222122212212122022221220212122221212222010220022100200212212220222211221222010222222222200022222212222222022120211122002111221202222221122212220222222222212212220022020220222222221220222222100120222201210022202211121121200221020211222202201222122222212220222021202022022110220112222220121112221221220221122222220122222222220212121220221222111221021210222102212201221121202221120221222222210022022202222221022120210112010021222212222220020012222221221220022112202222020221220202221222211222012021120102201020212221222201201220122201222212222022202202212220122022211002221221221122222222122112220222221222222002220122022220221222020222200222001120220011221002222202022121201220202222222012211122002212202212022221202022000220022012222221120212221220222221222112211122021222222202120120222222210222020021211122212211222010210222222222222022201122002202212222222220211202120122121122222221120222222220222221222212211122022222222222121222222222212020021201220102212210120012222220220200222112210112122202222221222022212022021001120122022221221202222221221220212012221222020220222222021121202222112221221200221010212202020022212221120211122112222112202212212222222122222212111121222102222222222122221220222102122202201022121221222222221021200222022022221221201022212202121110210220020200122112210122002222202221122021221222212202221102222220022022221222222220002212212122120221220222221120212222120002120100222212210210221112220221111210122022212022102212202221022122201122100222221112222220021112221220220001202022211220120222222222022222220222110202021201201211211211121122221220010220222102210222002202212202022221202002002000022202222220120122220221222101012202220220120220220212122222220222020222121010221101201212220212200222020221222222120212012202212221022120221212221221022002222222022222220222220000112002201021021221220222121122221222011120222012210210222212021120202221220211022122011012002212202200022022221122110000221112022220022002220222220211112102222221021220220202120221210222000212222022202102221212121200220222222222122122121222122002222222022121220212222210021002222222120222220221220122012022202020021220220202121220222221122112222202202220220220221211201222201212022002001012012212212002022020210112101010222122122221021022220021220000102112212122122221222202020022220221211112022020221200212200021121211222000202122012201222102002202112122221212002011110020202222221121222222022221101112112201220020221222222122121221221010222122222202222222212121000211221222210222102111002212112220022122020021102100200120222222220121102222020220210212202222020220222221212121220211222101212221000222010212222120011201222010220222112011222022102202121120020021212211001121102122221120112221222220021212122211020221221220212220121220222022122121102221102200222020010220220012200221202202222112112212120122021021022222110120222122222122222222121221112022012200121020220221202220122220220022112120002222002222210022212220222212212122122011112222022210211221222111102222210220002222222220222222121020202202212222121021220222220122021221221202200122122211101212201120012210221100221020002121012212212211100122021002222021101222212022220121012221221121122000112210202020220221212221120221221210111020020212220211022120212220222111201121012222022212122220021222120101212122102020212222220122012212020121000112102210020222221222212222122200221100022021001202201200211020201212220101200121122022002022202210020021120010212112122222202022221220102200021220021202012220021211020221210220021210220020001121022200100211101220202220220112220121222020112102112201000021221021122011010022102122221221012220021220112012012222200122120221222122222200222012201222112212221201010121220220222201202120102202202002212220002222220112222100002020102122221222122200121120111222102202021000221220222022121202222220210122210201121211111020121210220000200222012202122202022211212122121112022001002220222022220121002222010021221221102200200002121221201221022212222100021221211212200221010022102201221020201021122121202212122202002022020210112101022121222022221022122212012220002021102222011221122220210221020201221120102120000210022220002022021210220111212221012021112202222221001222122102112101102202012220220020212212201222202210102211002211222220202221120221202221110001022222102210012222022210222122222122102122002002222222002121020001122200102211222120222221002212202022000222022221200212022220220120021212200101111020222210211211211121001211220122211220112110112222022222022020022122122212022220222222222120202220122020002122102211111220121222220020220202202220221020222200210211101020002212222021221120012022012022022212101220222002212122000002222021222122022222110221202011202220202102121222211221222220202121101210110201121210100120011001201200220121102010102012212221011121221121202200022101212220221121212222100122101200002202201010120221212221022201212110100021012202210202200121022011222022221221102220022222122212002000120221002020010001202122222021202201200122121011102210111221122222202022020211211102122110212212111212001021000002221002220120122100122101112202210012021012112100121210112022220022022202110222012120102220101120120220222020220221212110110222222210002200221021222001222202210122102010122111202220100001120200112012210221122122221021122222100120112022022200001102120221001021020202211220002020212212211222221021002212210012200122222021122100102220001122220101022200011020202020220121022210212120121122012222122000020222001220222210212021020001212212021210021220111201200221221021102200022111022202221101220000122211220200102122220021002202111220011000120211200011221220201121122212211200000111011201202210201221021200201201211022212012112010122212020201220210212220002102112221222002022210110120122101222202110211120222222022122221220210111111120201122222222021000221211222220122112021012020102222020110221002222011112200022021222212102202200021200112010220000021020221022121021202222120012220121212202222212122211200202020112212201000121212121002220110002110100021100022111102102001020021122210001010211011100122202000000012101010012220220110102022202112111202022210121";

            int width = 25;
            int height = 6;

            var layer = input
                .Select((@char, i) => new { @char, index = i }) // Select all characters with their index in the list
                .GroupBy(c => c.index / width) // Create groups of size $width
                .Select((g, i) => new { grp = g.ToList(), index =  i}) // Select all groups with their index in the list of groups
                .GroupBy(grp => grp.index / height) // Then group those groups by $height to create the layers
                .Select(grp => grp.ToList()) // Select the items in the layer
                .OrderBy(grp => grp.Sum(g => g.grp.Count(c => c.@char == '0'))) // Order (ascendingly) by the amount of 0's in the whole layer
                .First() // And take the first one
                .SelectMany(grp => grp.grp.ToList()).ToList(); // Put all the rows in the layer in one big group for easy counting

            var result = layer.Count(c => c.@char == '1') * layer.Count(c => c.@char == '2');

            Console.WriteLine(result);
        }
    }
}
