#include "AGameViewController.h"


AAGameViewController::AAGameViewController()
    : gameModel{}
    , gameController{std::make_unique<core::GameController>(gameModel)}
{
    // empty
}

