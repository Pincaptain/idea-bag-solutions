cmake_minimum_required(VERSION 3.15)
project(binary_to_decimal_and_back_converter)

set(CMAKE_CXX_STANDARD 14)

add_executable(binary_to_decimal_and_back_converter src/main.cpp src/service/NumeralConverter.cpp src/service/NumeralConverter.h)