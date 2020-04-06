cmake_minimum_required(VERSION 3.10)

project(GameModel)

# we would like to use C++17,
# but UE4 still does not support it
set(CMAKE_CXX_STANDARD 14)

# we check if we have boost and defining
# boost library targets
find_package(Boost REQUIRED)

# process CMakeLists.txt files
# in subdirectories
add_subdirectory(core)
add_subdirectory(offline)

# defining cmake config file in case that someone
# would import our project by find_package(GameModel)
install(EXPORT GameModelTargets
        NAMESPACE GameModel::
        FILE game-model-config.cmake
        DESTINATION lib/cmake/GameModel)
