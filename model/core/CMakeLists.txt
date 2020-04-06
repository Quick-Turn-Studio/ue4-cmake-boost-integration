set(LIB_NAME coreLib)

project(${LIB_NAME})

aux_source_directory(. SRC_FILES)

add_library(${LIB_NAME} STATIC ${SRC_FILES})

# we use only header, but we would like to have access
# to boost include directory
target_link_libraries(${LIB_NAME} PUBLIC Boost::boost)

# when other CMake target will link to coreLib
# provide include directory
target_include_directories(${LIB_NAME} INTERFACE $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/.>
                                                 $<INSTALL_INTERFACE:include>)

# we list files that will be put into
# installed 'include' directory
set(PUBLIC_LIBRARY_HEADERS IGameModel.h IGameObserver.h GameController.h)

install(FILES ${PUBLIC_LIBRARY_HEADERS} DESTINATION include)

install(TARGETS ${LIB_NAME}
        EXPORT GameModelTargets
        ARCHIVE DESTINATION lib
        LIBRARY DESTINATION lib
        RUNTIME DESTINATION bin)
