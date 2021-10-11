#
# Project settings
#
cmake_minimum_required(VERSION 3.16)
project(heroes VERSION 111021)

# output library path 
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${PROJECT_SOURCE_DIR}/heroes/heroes/bin/Debug/net5.0)

add_subdirectory(engine)

# no lib prefix
SET_TARGET_PROPERTIES(engine PROPERTIES PREFIX "") 