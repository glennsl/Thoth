[<RequireQualifiedAccess>]
module Components.Navbar

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Fulma
    open Fulma.FontAwesome

    let private shadow =
        div [ ClassName "bd-special-shadow"
              Style [ Opacity 1.
                      Transform "scaleY(1)" ] ]
            [ ]

    let private viewSimpleIcon isHiddenDesktop =
        let inline props key url = Navbar.Item.Props [ Key ("simple-icon-"+ key)
                                                       Href url ]

        let visibility =
            if isHiddenDesktop then
                "is-hidden-desktop"
            else
                "is-hidden-mobile"

        [ Navbar.Item.a [ props "Github" "https://github.com/MangelMaxime/Thoth"
                          Navbar.Item.CustomClass visibility ]
            [ Icon.faIcon [ ]
                [ Fa.icon Fa.I.Github
                  Fa.faLg ] ]
          Navbar.Item.a [ props "Twitter" "https://twitter.com/MangelMaxime"
                          Navbar.Item.CustomClass ("twitter " + visibility) ]
            [ Icon.faIcon [ ]
                [ Fa.icon Fa.I.Twitter
                  Fa.faLg ] ]
        ] |> ofList

    let tweetUrl = "https://twitter.com/intent/tweet?via=MangelMaxime&text=Thoth%20is%20a%20set%20of%20several%20libraries%20for%20working%20with%20@FableCompiler%20applications"

    let private viewButton =
        Navbar.Item.div [ ]
            [ Field.div [ Field.IsGrouped ]
                [ Control.p [ ]
                    [ Button.a [ Button.CustomClass "twitter"
                                 Button.Props [ Href tweetUrl
                                                Target "_blank" ] ]
                        [ Icon.faIcon [ ]
                            [ Fa.icon Fa.I.Twitter
                              Fa.faLg ]
                          span [ ] [ str "Tweet" ]
                        ]
                    ]
                  Control.p [ ]
                    [ Button.a [ Button.CustomClass "github"
                                 Button.Props [ Href "https://github.com/MangelMaxime/Thoth" ] ]
                        [ Icon.faIcon [ ]
                            [ Fa.icon Fa.I.Github
                              Fa.faLg ]
                          span [ ] [ str "Github" ]
                        ]
                    ]
                ]
            ]

    let private navbarEnd =
        Navbar.End.div [ ]
            [ viewSimpleIcon false
              viewButton ]

    let private navbarJson pageUrl =
        Navbar.Dropdown.div [ ]
            [ Navbar.Item.a [ Navbar.Item.IsActive (pageUrl = Route.Json.Decode)
                              Navbar.Item.Props [ Href Route.Json.Decode ] ]
                [ str "Decode" ]
              Navbar.Item.a [ Navbar.Item.IsActive (pageUrl = Route.Json.Encode )
                              Navbar.Item.Props [ Href Route.Json.Encode ] ]
                [ str "Encode" ]
              Navbar.Item.a [ Navbar.Item.IsActive (pageUrl = Route.Json.Net )
                              Navbar.Item.Props [ Href Route.Json.Net ] ]
                [ str ".Net & NetCore" ] ]

    let private navbarElmish pageUrl =
        Navbar.Dropdown.div [ ]
            [ Navbar.Item.a [ Navbar.Item.IsActive (pageUrl = Route.Elmish.Debouncer)
                              Navbar.Item.Props [ Href Route.Elmish.Debouncer ] ]
                [ str "Debouncer" ] ]

    let private navbarMenu pageUrl =
        Navbar.menu [ Navbar.Menu.Props [ Id "navMenu" ] ]
            [ Navbar.Item.div [ Navbar.Item.HasDropdown
                                Navbar.Item.IsHoverable ]
                [ Navbar.Link.div [ ]
                    [ str "Json" ]
                  navbarJson pageUrl ]
              Navbar.Item.div [ Navbar.Item.HasDropdown
                                Navbar.Item.IsHoverable ]
                [ Navbar.Link.div [ ]
                    [ str "Elmish" ]
                  navbarElmish pageUrl ]
                   ]

    let private navbarBrand =
        Navbar.Brand.div [ ]
            [ Navbar.Item.a [ Navbar.Item.Props [ Href Route.Index ] ]
                [ Heading.p [ Heading.Is4 ]
                    [ str "Thoth" ] ]
              viewSimpleIcon true
              Navbar.burger [ ]
                [ span [ ] [ ]
                  span [ ] [ ]
                  span [ ] [ ] ] ]

    let render pageUrl =
        Navbar.navbar [ Navbar.Color IsPrimary
                        Navbar.CustomClass "is-fixed-top" ]
            [ shadow
              Container.container [ ]
                [ navbarBrand
                  navbarMenu pageUrl
                  navbarEnd ] ]
