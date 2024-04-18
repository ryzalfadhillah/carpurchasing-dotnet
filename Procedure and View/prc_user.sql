CREATE OR REPLACE PROCEDURE public.PRC_UPSERT_USER (
    IN p_username VARCHAR,
    IN p_password VARCHAR,
    IN p_status VARCHAR,
    IN p_id_sales UUID,
    IN p_id_user VARCHAR,
    OUT out_mess VARCHAR
)
LANGUAGE plpgsql
AS $prc_user$
DECLARE
    v_found boolean;
    v_found_sales boolean;
BEGIN
    -- Cek apakah id_sales ada dalam MST_SALES
    SELECT EXISTS(SELECT 1 FROM "MST_SALES" WHERE id_sales = p_id_sales) INTO v_found_sales;
    
    -- Jika id_sales tidak ditemukan
    IF NOT v_found_sales THEN
        out_mess := 'ID sales tidak ditemukan';
    ELSE
        -- Cek apakah username sudah ada dalam MST_USER
        SELECT EXISTS(SELECT 1 FROM "MST_USER" WHERE username = p_username) INTO v_found;

        IF v_found THEN
            -- Jika username sudah ada, lakukan update
            UPDATE "MST_USER"
            SET username = p_username,
                "password" = p_password,
                status = p_status,
                id_sales = p_id_sales,
                dt_updated = current_timestamp,
                id_user_added = p_id_user
            WHERE username = p_username;
            
            out_mess := 'User dengan username ' || p_username || ' telah diperbaharui';
        ELSE
            -- Jika username belum ada, lakukan insert
            INSERT INTO "MST_USER" (id ,username, "password", status, id_sales, dt_added,dt_updated, id_user_added)
            VALUES (gen_random_uuid() ,p_username, p_password, p_status, p_id_sales, current_timestamp, current_timestamp, p_id_user);
        
            out_mess := 'User baru telah ditambahkan';
        END IF;
    END IF;

    COMMIT;
END $prc_user$;