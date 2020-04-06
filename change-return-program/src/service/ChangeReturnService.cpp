//
// Created by Gjorovski on 4/6/2020.
//

#include <iostream>

#include "ChangeReturnService.h"

ChangeReturnService::ChangeReturnService(float price, float payment) {
    this->price = price;
    this->payment = payment;
}

#pragma clang diagnostic push
#pragma ide diagnostic ignored "bugprone-narrowing-conversions"
std::vector<int> ChangeReturnService::calculate() {
    // List of pairs
    // First element in pairs is type
    // Second element is count
    std::vector<int> change = std::vector<int>();

    // Amount to return
    int to_return = (payment - price) * 100;

    // Calculate the amount of coins
    change.insert(change.end(), to_return / 25);
    to_return = to_return % 25;
    change.insert(change.end(), to_return / 10);
    to_return = to_return % 10;
    change.insert(change.end(), to_return / 5);
    to_return = to_return % 5;
    change.insert(change.end(), to_return);

    return change;
}
#pragma clang diagnostic pop