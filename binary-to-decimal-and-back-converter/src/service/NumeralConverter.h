//
// Created by Gjorovski on 4/7/2020.
//

#ifndef BINARY_TO_DECIMAL_AND_BACK_CONVERTER_NUMERALCONVERTER_H
#define BINARY_TO_DECIMAL_AND_BACK_CONVERTER_NUMERALCONVERTER_H

#include <string>

enum NumeralSystem {
    BINARY,
    DECIMAL,
    OCTAL,
    HEXADECIMAL,
};

class NumeralConverter {
private:
    NumeralSystem from;
    NumeralSystem to;
public:
    NumeralConverter(NumeralSystem from, NumeralSystem to);
    std::string convert(const std::string&);
    std::string binaryToDecimal(const std::string& binary);
    std::string binaryToOctal(const std::string& binary);
    std::string binaryToHexadecimal(const std::string& binary);
    std::string decimalToBinary(const std::string& decimal);
    std::string decimalToOctal(const std::string& decimal);
    std::string decimalToHexadecimal(const std::string& decimal);
};


#endif //BINARY_TO_DECIMAL_AND_BACK_CONVERTER_NUMERALCONVERTER_H
