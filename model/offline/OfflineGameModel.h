#pragma once

#include <IGameModel.h>

namespace models
{

class OfflineGameModel : public core::IGameModel
{
public:
    OfflineGameModel();
    ~OfflineGameModel() override;

public: // overridden from core::IGameModel
    int getPlayersCount() const override;
    int getPlayerMoney(int playerNumber) override;
    bool performAction(const core::Action& action) override;
};

} // namespace models
