CREATE OR REPLACE PROCEDURE public.prc_upsert_usage(
 IN p_name VARCHAR,
    in p_id_user VARCHAR,
    OUT out_mess VARCHAR(100)
)
LANGUAGE plpgsql
AS $$
begin

    IF EXISTS (SELECT 1 FROM "MST_USAGE" WHERE name = p_name) then

        UPDATE "MST_USAGE"
        SET dt_updated = CURRENT_TIMESTAMP,
            id_user_updated = p_id_user
        WHERE name = p_name;

        out_mess := 'Usage ' || p_name || ' telah diupdate';
    ELSE

     INSERT INTO "MST_USAGE" (name, dt_added, dt_updated, id_user_added, id_user_updated)
        VALUES (p_name, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, p_id_user, p_id_user);

        out_mess := 'Usage ' || p_name || ' telah ditambahkan';
    END IF;
END;
$$;