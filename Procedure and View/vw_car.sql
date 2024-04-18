create or replace view VW_MST_CAR as
select mc.engine_size as "Engine Size", mc.fuel_type as "Fuel Type", mc.manufacture_year as "Manufacture Year",
mc.cd_chassis as "Chassis Code", mc.cd_engine as "Engine Code", mb.name as "Brand", mt.name as "Type",
mu.name as "Usage", mm.name as "Model"
from "MST_CAR" mc
join "MST_BRAND" mb on mc.brand_id = mb.id
join "MST_TYPE" mt on mc.type_id = mt.id
join "MST_USAGE" mu on mc.usage_id = mu.id
join "MST_MODEL" mm on mc.model_id = mm.id;h