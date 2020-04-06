#include <iostream>
#include <string>

#include "service/ChangeReturnService.h"

int main(int count, char** args) {
    if (count != 3) {
        std::cout << "Insufficient number of parameters." << std::endl;
        return 1;
    }

    float price = 0;
    float payment = 0;
    try {
        price = std::stof(args[1]);
        payment = std::stof(args[2]);
    } catch (const std::exception& exc) {
        std::cout << "Invalid parameters provided." << std::endl;
        return 1;
    }

    auto service = new ChangeReturnService(price, payment);
    std::vector<int> change = service->calculate();

    std::cout << "Quarters: " << change[0] << std::endl;
    std::cout << "Dimes: " << change[1] << std::endl;
    std::cout << "Nickels: " << change[2] << std::endl;
    std::cout << "Pennies: " << change[3] << std::endl;

    return 0;
}
