const SidebarData = [
    {
        id: 1,
        name: "the oasis",
        show: false,
        subMenu: [
            {
                id: 1,
                name: "about",
            },
            {
                id: 2,
                name: "documentation",
            },
            {
                id: 3,
                name: "our world",
            },
        ],
    },
    {
        id: 2,
        name: "avatar",
        show: false,
        subMenu: [
            {
                id: 1,
                name: "View Avatar",
                popupName:"viewAvatar"
            },
            {
                id: 2,
                name: "Edit Avatar",
            },
            {
                id: 3,
                name: "Search Avatars",
                popupName:"searchAvatar"
            },
            {
                id: 4,
                name: "Avatar Wallet",
                popupName:"avatarWallet"
            },
            {
                id: 5,
                name: "Avatar Detail",
                popupName:"avatarDetail"
            },
        ],
    },
    {
        id: 3,
        name: "karma",
        subMenu: [
            {
                id: 1,
                name: "View Curent Karma Weightings",
            },
            {
                id: 2,
                name: "Vote For Karma Weightings",
            },
            {
                id: 3,
                name: "View Avatar Karma",
            },
            {
                id: 4,
                name: "View/Search Karma Akashic Records",
            },
        ],
    },
    {
        id: 4,
        name: "data",
        subMenu: [
            {
                id: 1,

                name: "Load Data",
                popupName: "loadData",
            },
            {
                id: 2,
                name: "Send Data",
                popupName: "sendData",
            },
            {
                id: 3,
                name: "Manage Data",
                popupName: "manageData",
            },
            {
                id: 4,
                name: "Cross-Chain Management",
                popupName: 'crossChainManagement'
            },
            {
                id: 5,
                name: "Off-Chain Management",
                popupName: 'offChainManagement'
            },
            {
                id: 6,
                name: "Search Data",
            },
        ],
    },
    {
        id: 5,
        name: "seeds",
        subMenu: [
            {
                id: 1,
                name: "Pay With SEEDS",
                popupName: "payWithSeeds" 
            },
            {
                id: 2,
                name: "Donate SEEDS",
                popupName: "donateSeeds"
            },
            {
                id: 3,
                name: "Reward SEEDS",
                popupName: "rewardSeeds"
            },
            {
                id: 4,
                name: "Send Invite To Join SEEDS",
                popupName:"sendInvite"
            },
            {
                id: 5,
                name: "Accept Invite",
                popupName: "acceptInvite" 
            },
            {

                name: "data",
                subMenu: [
                    {
                        id: 1,
                        name: "Load Data",
                        popupName: 'loadData'
                    },
                    {
                        id: 2,
                        name: "Send Data",
                        popupName: 'sendData'
                    },
                    {
                        id: 3,
                        name: "Manage Data",
                        popupName: 'manageData'
                    },
                    {
                        id: 4,
                        name: "Cross-Chain Management",
                        popupName: 'crossChainManagement'
                    },
                    {
                        id: 5,
                        name: "Off-Chain Management",
                        popupName: 'offChainManagement'
                    },
                    {
                        id: 6,
                        name: "Search Data",
                    },
                  
                ]
            },
            {

                id: 5,
                name: "Accept Invite to join seeds",
            },
            {
                id: 6,
                name: "View SEEDS",
                popupName: "viewseeds"
            },
            {
                id: 7,
                name: "View Organisations",
            },
            {
                id: 8,
                name: "Manage SEEDS",
            },
            {
                id: 9,
                name: "Search Seeds",
                // popupName: "searchseeds"
            },
        ],
    },
    {
        id: 6,
        name: "provider",
        subMenu: [
            // {
            //     id: 0,
            //     name: <Link to="/provider/key-management"> key Managment</Link>,
            // },
            // {
            //     id: 1,
            //     name: <Link to="/provider/provider"> View Providers</Link>,
            // },
            {
                id: 2,
                name: "Manage Providers",
            },

            {
                id: 3,
                name: "Manage Auto-Replication",
            },
            {
                id: 4,
                name: "Manage Auto-Fail-Over",
            },
            {
                id: 5,
                name: "Manage Load Balancing",
            },
            {
                id: 6,
                name: "View Provider Stats",
            },
            {
                id: 7,
                name: "Compare Provider Speeds",
            },
            {
                id: 8,
                name: "Search Providers",
            },
            {
                id: 9,
                name: "Holochain",
            },
            {
                id: 10,
                name: "SEEDS",
            },
            {
                id: 11,
                name: "EOSIO",
            },
            {
                id: 12,
                name: "Ethereum",
            },
            {
                id: 13,
                name: "IPFS",
            },
            {
                id: 14,
                name: "ThreeFold",
            },
            {
                id: 15,
                name: "SOLID",
            },
            {
                id: 16,
                name: "Activity Pub",
            },
            {
                id: 17,
                name: "Mongo DB",
            },
            {
                id: 18,
                name: "SQLLite",
            },
            {
                id: 19,
                name: "Neo4j",
            },
        ],
    },
    {
        id: 7,
        name: "nft",
        subMenu: [
            {
                id: 1,
                name: "Solana",
                popupName: 'solana'
            },
            {
                id: 2,
                name: "Contact Popup",
                popupName: 'contactPopup'
            }
        ],
    },
    {
        id: 8,
        name: "map",
        subMenu: [],
    },
    {
        id: 9,
        name: "oapp",
        subMenu: [],
    },
    {
        id: 10,
        name: "quest",
        subMenu: [],
    },
    {
        id: 11,
        name: "mission",
        subMenu: [],
    },
    {
        id: 12,
        name: "egg",
        subMenu: [],
    },
    {
        id: 13,
        name: "game",
        subMenu: [
            {
                id: 1,
                name: "View StarCraft 2 Leagues",
            },
            {
                id: 2,
                name: "View StarCraft 2 Tournaments",
            },
            {
                id: 3,
                name: "View StarCraft 2 Achievements",
            },
        ],
    },
    {
        id: 14,
        name: "developer",
        subMenu: [],
    },
];

export default SidebarData;
