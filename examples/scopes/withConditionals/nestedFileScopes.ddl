scope (true || false)
{
    scope ( Define1 != "Something" || false)
    {
        scope (Define1 && (Define2 != "Something") && false)
        {
            scope (Define1 && ((Define2 != "Something") || false ))
            {
            }

            scope (Define1 && !((!Define2) || false ))
            {
            }
        }
    }
}