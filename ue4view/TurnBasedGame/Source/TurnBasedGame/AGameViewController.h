#pragma once

#include <memory>

THIRD_PARTY_INCLUDES_START
#include <GameController.h>
#include <OfflineGameModel.h>
THIRD_PARTY_INCLUDES_END

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "AGameViewController.generated.h"

UCLASS()
class TURNBASEDGAME_API AAGameViewController : public AActor
{
    GENERATED_BODY()
	
public:	
    AAGameViewController();

private: // members
    models::OfflineGameModel gameModel;
    // no default constructor for GameController,
    // so we need to wrap it to prevent UE4 generator fail
    std::unique_ptr<core::GameController> gameController;
};
