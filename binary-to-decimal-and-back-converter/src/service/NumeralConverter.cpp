//
// Created by Gjorovski on 4/7/2020.
//

#include "NumeralConverter.h"

#include <iostream>

NumeralConverter::NumeralConverter(NumeralSystem from, NumeralSystem to) {
    this->from = from;
    this->to = to;
}

std::string NumeralConverter::convert(const std::string& input) {
    switch (from) {
        case BINARY:
            switch (to) {
                case DECIMAL:
                    return binaryToDecimal(input);
                case OCTAL:
                    return binaryToOctal(input);
                case HEXADECIMAL:
                    return binaryToHexadecimal(input);
                default:
                    return nullptr;
            }
        case DECIMAL:
            switch (to) {
                case BINARY:
                    return decimalToBinary(input);
                case OCTAL:
                    return decimalToOctal(input);
                case HEXADECIMAL:
                    return decimalToHexadecimal(input);
                default:
                    return nullptr;
            }
        default:
            return nullptr;
    }
}

#pragma clang diagnostic push
#pragma ide diagnostic ignored "bugprone-narrowing-conversions"
#pragma ide diagnostic ignored "MemberFunctionCanBeStatic"
std::string NumeralConverter::binaryToDecimal(const std::string& binary) {
    int decimal = 0;

    for (int i = 0; i < binary.length(); ++i) {
        if (binary[i] == '1') {
            decimal += pow(2, binary.length() - 1 - i);
        }
    }

    return std::to_string(decimal);
}
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma ide diagnostic ignored "bugprone-narrowing-conversions"
std::string NumeralConverter::binaryToOctal(const std::string& binary) {
    int decimal_integer = std::stoi(binaryToDecimal(binary));
    std::string octal = std::string();

    while (decimal_integer != 0) {
        octal.insert(octal.begin(), '0' + (decimal_integer % 8));
        decimal_integer /= 8;
    }

    return octal;
}
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma ide diagnostic ignored "bugprone-narrowing-conversions"
std::string NumeralConverter::binaryToHexadecimal(const std::string& binary) {
    int decimal_integer = std::stoi(binaryToDecimal(binary));
    std::string hexadecimal = std::string();

    while (decimal_integer != 0) {
        int n = decimal_integer % 16;
        char c;
        if (n > 9) {
            c = 65 + n - 10;
        } else {
            c = '0' + n;
        }

        hexadecimal.insert(hexadecimal.begin(), c);
        decimal_integer /= 16;
    }

    return hexadecimal;
}
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma ide diagnostic ignored "MemberFunctionCanBeStatic"
std::string NumeralConverter::decimalToBinary(const std::string& decimal) {
    int decimal_integer = std::stoi(decimal);
    std::string binary = std::string();

    while (decimal_integer != 0) {
        binary.insert(binary.begin(), '0' + (decimal_integer % 2));
        decimal_integer /= 2;
    }

    return binary;
}
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma ide diagnostic ignored "MemberFunctionCanBeStatic"
std::string NumeralConverter::decimalToOctal(const std::string& decimal) {
    int decimal_integer = std::stoi(decimal);
    std::string octal = std::string();

    while (decimal_integer != 0) {
        octal.insert(octal.begin(), '0' + (decimal_integer % 8));
        decimal_integer /= 8;
    }

    return octal;
}
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma ide diagnostic ignored "MemberFunctionCanBeStatic"
#pragma ide diagnostic ignored "bugprone-narrowing-conversions"
std::string NumeralConverter::decimalToHexadecimal(const std::string& decimal) {
    int decimal_integer = std::stoi(decimal);
    std::string hexadecimal = std::string();

    while (decimal_integer != 0) {
        int n = decimal_integer % 16;
        char c;
        if (n > 9) {
            c = 65 + n - 10;
        } else {
            c = '0' + n;
        }

        hexadecimal.insert(hexadecimal.begin(), c);
        decimal_integer /= 16;
    }

    return hexadecimal;
}
#pragma clang diagnostic pop
