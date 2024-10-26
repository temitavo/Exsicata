INCLUDE Globals.ink

~ current_plant_interaction = "plant_02"

{plant_pot_02 == "":
    -> to_choose
  - else:
    -> already_chose
}

=== to_choose ===
Hmmm... Que muda que eu vou plantar aqui?
    + [Uma muda de girassol.]
        Será?
            + + [Sim!]
                ~ plant_pot_02 = "girassol"
                -> chosen
            + + [Não...]
                -> not_chosen
    + [Uma muda de lírio.]
        Será?
            + + [Sim!]
                ~ plant_pot_02 = "lírio"
                -> chosen
            + + [Não...]
                -> not_chosen
    + [Uma muda de orquídea.]
        Será?
            + + [Sim!]
                ~ plant_pot_02 = "orquídea"
                -> chosen
            + + [Não...]
                -> not_chosen
    + [Nenhuma.]
        -> not_chosen
        
=== chosen ===
~ to_plant_02 = true
Plantei uma muda de {plant_pot_02}.
-> ending

=== not_chosen ===
Decidi não plantar.
-> ending

=== already_chose ===
Aqui está plantado um pé de {plant_pot_02}.
{plant_02_stage < 3:
    -> growing
  - else:
    -> will_you_store
}

=== growing ===
Ainda está se desenvolvendo.
Acho que volto aqui mais tarde.
->ending

=== will_you_store ===
Será que eu já guardo esta planta?
    + [Sim.]
        { plant_pot_02:
        - "girassol":   -> harvested_girassol
        - "lírio":   -> harvested_lirio
        - "orquídea":   -> harvested_orquidea
        }
    + [Não.]
        Tudo bem.
        Este pé de {plant_pot_02} continuará aqui.
        -> ending

=== harvested_girassol ===
~ harvest_02 = true
~ quanti_girassol = quanti_girassol + 1
{quanti_girassol > 1:
    Agora, tenho {quanti_girassol} unidades de girassol no inventário.
    -> ending
  - else:
    Agora, tenho {quanti_girassol} unidade de girassol no inventário.
    -> ending
}

=== harvested_lirio ===
~ harvest_02 = true
~ quanti_lirio = quanti_lirio + 1
{quanti_lirio > 1:
    Agora, tenho {quanti_lirio} unidades de lírio no inventário.
    -> ending
  - else:
    Agora, tenho {quanti_lirio} unidade de lírio no inventário.
    -> ending
}

=== harvested_orquidea ===
~ harvest_02 = true
~ quanti_orquidea = quanti_orquidea + 1
{quanti_orquidea > 1:
    Agora, tenho {quanti_orquidea} unidades de orquídea no inventário.
    -> ending
  - else:
    Agora, tenho {quanti_orquidea} unidade de orquídea no inventário.
    -> ending
}

=== ending ===
~ current_plant_interaction = ""
-> END