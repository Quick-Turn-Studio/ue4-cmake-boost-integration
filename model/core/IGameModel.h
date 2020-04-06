#pragma once

namespace core
{

struct Action;

class IGameModel
{
public:
    virtual ~IGameModel() = default;

    virtual int getPlayersCount() const = 0;
    virtual int getPlayerMoney(int playerNumber) = 0;
    virtual bool performAction(const Action& action) = 0;
};

} // namespace core