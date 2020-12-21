<?php


class Utils
{
    public static function getPDO(): PDO
    {
        $options = [
            PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
            PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
        ];
        return new PDO('mysql:host=db;dbname=kinos', 'devuser', 'devpass', $options);
    }
}