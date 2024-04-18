create or replace procedure public.PRC_UPSERT_MODEL(in p_model_id int, in p_model_name varchar, in p_brand_id int, in p_user_id uuid, out status boolean, out out_mess varchar)
language plpgsql
as $$
declare
v_model_id int;
v_found int;
begin

 -- cek apakah id model ada atau tidak untuk menentukan action (insert or update)
 if (p_model_id = 0) then --jika id ketika input 0 (buat type hidden value 0 di form)
  insert into "MST_MODEL" (name, brand_id, dt_added, dt_updated, id_user_added, id_user_updated)
  values (p_model_name, v_brand_id, current_timestamp, current_timestamp, p_user_id, p_user_id)
  returning id into v_model_id;
 else
  update "MST_MODEL"
  set name = p_model_name, brand_id = v_brand_id, dt_updated = current_timestamp, id_user_updated = p_user_id
  where id = p_model_id returning id into v_model_id;
 end if;

 -- cek input status
 select count(0) into v_found from "MST_MODEL"
 where id = v_model_id;

 --generate output
 if v_found > 0 then
  status := true;
  out_mess := 'input model successed';
 else
  status := false;
  out_mess := 'input model failed';
 end if;

 commit;
end; $$