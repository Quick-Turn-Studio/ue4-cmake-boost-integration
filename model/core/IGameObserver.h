#pragma once

namespace core
{

struct Action;
class IGameModel;

class IGameObserver
{
public:
    virtual ~IGameModel() = default;

    // to have a handle to get some information
    virtual void init(const IGameModel& gameModel) = 0;

    // called by controller when action on model is performed
    virtual void virtual void onActionPerformed(const Action& action) = 0;
};

} // namespace core
