#pragma once

#include <memory>
#include <vector>

namespace core
{

class IGameModel;
class IGameObserver;
using IGameObserverPtr = std::shared_ptr<IGameObserver>;

class GameController
{
public:
    explicit GameController(IGameModel& gameModel);

    // add game observer. Notice that game can have more that one observer
    void addObserver(IGameObserverPtr observer);

    // starts game model loop and return winning player number
    int startGame();

private: // members
    IGameModel& gameModel;
    std::vector<IGameObserverPtr> gameObservers;
};

} // namespace core
