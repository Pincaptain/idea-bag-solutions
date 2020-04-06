cmake_minimum_required(VERSION 3.15)
project(change_return_program)

set(CMAKE_CXX_STANDARD 14)

add_executable(change_return_program src/main.cpp src/service/ChangeReturnService.cpp)