CREATE OR REPLACE PROCEDURE public.prc_upsert_brand(
 IN p_name VARCHAR,
    IN p_country VARCHAR,
    in p_id_user_added VARCHAR,
    OUT out_mess VARCHAR(100)
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Cek apakah nama brand sudah ada dalam tabel brand
    IF EXISTS (SELECT 1 FROM mst_brand WHERE name = p_name) THEN
        -- Jika sudah ada, lakukan UPDATE pada country dan dt_updated
        UPDATE mst_brand
        SET country = p_country,
            dt_updated = CURRENT_TIMESTAMP,
            id_user_added = p_id_user_added
        WHERE name = p_name;

        out_mess := 'Brand ' || p_name || ' telah diupdate dengan negara ' || p_country;
    ELSE
        -- Jika belum ada, lakukan INSERT dan isi dt_added dan id_user_added
        INSERT INTO mst_brand (name, country, dt_added, dt_updated, id_user_added)
        VALUES (p_name, p_country, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, p_id_user_added);

        out_mess := 'Brand ' || p_name || ' dengan negara ' || p_country || ' telah ditambahkan';
    END IF;
END;
$$;