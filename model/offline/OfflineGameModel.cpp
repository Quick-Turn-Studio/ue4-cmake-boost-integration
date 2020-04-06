#include "OfflineGameModel.h"

#include <iostream>
#include <stdexcept>

#include <Actions.h>

namespace models
{

OfflineGameModel::~OfflineGameModel() = default;

OfflineGameModel::OfflineGameModel() = default;

int OfflineGameModel::getPlayersCount() const
{
    throw std::runtime_error{"not implemented"};
}

int OfflineGameModel::getPlayerMoney(int playerNumber)
{
    throw std::runtime_error{"not implemented"};
}

bool OfflineGameModel::performAction(const core::Action& action)
{
    switch (action.type) {
		case core::ActionType::BuildBuilding: {
			const auto data = boost::get<core::BuildBuildingData>(action.actionData);
			std::cout << "We have to build id: " << data.buildingId << "\n";
			break;
		}
		case core::ActionType::RecruitBattleUnit: {
			const auto data = boost::get<core::RecruitBattleUnitData>(action.actionData);
			std::cout << "We have to recruit id: " << data.battleUnitId << "\n";
			break;
		}
    }
    return true;
}

} // namespace models
