#pragma once

#include <boost/variant.hpp>

namespace core
{

struct BuildBuildingData
{
    int fieldNumber;
    int buildingId;
};

struct RecruitBattleUnitData
{
    int battleUnitId;
};

enum class ActionType
{
    BuildBuilding,
    RecruitBattleUnit,
};

struct Action
{
    ActionType type;
    boost::variant<BuildBuildingData, RecruitBattleUnitData> actionData;
};

} // namespace core