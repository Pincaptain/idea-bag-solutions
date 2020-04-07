#include <iostream>

#include "service/NumeralConverter.h"

int main(int count, char** args) {
    if (count != 4) {
        std::cout << "Invalid number of parameters." << std::endl;
        return 1;
    }

    std::string input;
    NumeralSystem from;
    NumeralSystem to;
    try {
        input = args[1];
        from = strcmp(args[2], "binary") == 0 ? BINARY : DECIMAL;
        to = strcmp(args[3], "binary") == 0 ? BINARY :
                strcmp(args[3], "decimal") == 0 ? DECIMAL :
                strcmp(args[3], "octal") == 0 ? OCTAL : HEXADECIMAL;
    } catch (std::exception& exc) {
        std::cout << "Invalid parameters provided." << std::endl;
        return 1;
    }

    auto numeralConverter = new NumeralConverter(from, to);
    std::cout << numeralConverter->convert(input) << std::endl;
    return 0;
}
