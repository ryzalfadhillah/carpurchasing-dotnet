create or replace procedure public.PRC_UPSERT_TYPE (
 in p_id integer,
 in p_name varchar,
 in p_user_id varchar,
 out out_stat boolean,
 out out_mess varchar
)
language plpgsql
as $prc_type$
declare
 v_found boolean;
begin
 if(p_id != 0) then
  select exists(select 1 from "MST_TYPE" where id = p_id)
  into v_found;

  if v_found then
   update "MST_TYPE" set("name", id_user_updated, dt_updated) = (p_name, p_user_id::uuid, current_timestamp) where id = p_id;
   out_stat := true;
   out_mess := 'Type ' || p_name || ' telah diperbarui';
  else
   out_stat := false;
   out_mess := 'type tidak ditemukan';
  end if;
 else
  select exists(select 1 from "MST_TYPE" where "name" like p_name)
  into v_found;

  if v_found then
   out_stat := false;
   out_mess := 'type duplikasi!';h
  else
   insert into "MST_TYPE"("name", id_user_added, dt_added) values(p_name, p_user_id::uuid, current_timestamp);
   out_stat := true;
   out_mess := 'Type ' || p_name || ' telah ditambahkan';
  end if;
 end if;
commit;
end $prc_type$;


do $$
declare
	status boolean;
begin
	call tambah_actor('Robertus', 'Christopher', status);
	raise notice 'Status: %', status;
end $$;
