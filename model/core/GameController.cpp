#include "GameController.h"

#include "IGameModel.h"

namespace core
{

GameController::GameController(IGameModel& gameModel)
  : gameModel{gameModel}
{
    // empty
}

void GameController::addObserver(std::shared_ptr<IGameObserver> observer)
{
    gameObservers.push_back(std::move(observer));
}

int GameController::startGame()
{
    throw std::runtime_error{"not implemented"};
}

} // namespace core
