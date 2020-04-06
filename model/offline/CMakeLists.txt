set(LIB_NAME offlineModel)

project(${LIB_NAME})

aux_source_directory(. SRC_FILES)

add_library(${LIB_NAME} STATIC ${SRC_FILES})

# link to coreLib to have access to core::IGameModel
# files and implementations
target_link_libraries(${LIB_NAME} PUBLIC coreLib)

target_include_directories(${LIB_NAME}
        INTERFACE $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/.>
                  $<INSTALL_INTERFACE:include>)

set(PUBLIC_LIBRARY_HEADERS OfflineGameModel.h)

install(FILES ${PUBLIC_LIBRARY_HEADERS} DESTINATION include)

install(TARGETS ${LIB_NAME}
        EXPORT GameModelTargets
        ARCHIVE DESTINATION lib
        LIBRARY DESTINATION lib
        RUNTIME DESTINATION bin)
